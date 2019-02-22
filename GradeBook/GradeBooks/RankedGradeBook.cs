using GradeBook.Enums;
using System;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked grading requires five or more students");
            var studentGradeOrder = Students.OrderByDescending(e => e.AverageGrade).ToList();
            var studentPercential = averageGrade / Students.Count;
            int count = 0;
            foreach (var pupil in studentGradeOrder)
            {
                count += 1;
                if (count <= .2 * (studentGradeOrder.Count / 5))
                {
                    return 'A';
                }
                else if (count <= .4 * (studentGradeOrder.Count / 5))
                {
                    return 'B';
                }
                else if (count <= .6 * (studentGradeOrder.Count / 5))
                {
                    return 'C';
                }
                else if (count <= .8 * (studentGradeOrder.Count / 5))
                {
                    return 'D';
                }
                else
                {
                    return 'A';
                }
            }
            return 'F';
        }
    }
}
