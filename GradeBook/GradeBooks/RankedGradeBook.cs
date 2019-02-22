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
                if (averageGrade == studentGradeOrder[count - 1].AverageGrade)
                {
                    if (count <= studentGradeOrder.Count * .2)
                    {
                        return 'A';
                    }
                    else if (count <= studentGradeOrder.Count * .4)
                    {
                        return 'B';
                    }
                    else if (count <= studentGradeOrder.Count * .6)
                    {
                        return 'C';
                    }
                    else if (count <= studentGradeOrder.Count * .8)
                    {
                        return 'D';
                    }
                    else
                    {
                        return 'F';
                    }
                }
            }
            return 'F';
        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
            else
            base.CalculateStudentStatistics(name);
        }
    }
}
