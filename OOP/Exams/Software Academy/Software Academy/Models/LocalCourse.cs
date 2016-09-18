namespace Software_Academy.Models
{
    using System;
    using Software_Academy.Interfaces;

     public class LocalCourse : Course, ILocalCourse, ICourse
    {
        private string lab;
        public LocalCourse(string name, ITeacher teacher, string lab)
            : base(name, teacher)
        {
            
            this.Lab = lab;
        }
        public LocalCourse(string name, string lab)
            : base(name)
        {
            this.Lab = lab;
        }

        public string Lab
        {
            get { return this.lab; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }
                this.lab = value;
            }
        }

        public override string ToString()
        {
             return string.Format("{0}; Lab={1}", base.ToString(), this.Lab);
        }
    }
}
