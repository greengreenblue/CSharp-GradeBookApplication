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
            foreach (var pupil in Students)
            {
                if (pupil.AverageGrade >= (averageGrade - studentPercential))
                {
                    return 'A';
                }
                else if (pupil.AverageGrade >= (averageGrade - 30 * studentPercential))
                {
                    return 'B';
                }
                else if (pupil.AverageGrade >= (averageGrade - 4 * studentPercential))
                {
                    return 'C';
                }
                else if (pupil.AverageGrade >= (averageGrade - 5 * studentPercential))
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
