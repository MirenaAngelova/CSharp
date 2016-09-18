namespace Software_Academy.Models
{
    using System;

    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Software_Academy.Interfaces;

    public abstract class Course : ICourse
    {
        private string name;
        private ITeacher teacher;
        private ICollection<string> topics;
        public Course(string name, ITeacher teacher)
        {
            this.Name = name;
            this.Teacher = teacher;
            this.topics = new List<string>();
        }
        public Course(string name)
        {

        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                this.name = value;
            }
        }

        public ITeacher Teacher
        {
            get
            {
                return this.teacher;

            }
            set
            {
                this.teacher = value;
                
            }
        }
        public void AddTopic(string topic)
        {
            this.topics.Add(topic);
        }

        public override string ToString()
        {
            string exit = string.Format("{0}: Name={1}", this.GetType().Name, this.Name);
            if (this.teacher != null)
            {
                exit += string.Format("; Teacher={0}", this.Teacher.Name);
            }
            if (this.topics.Count > 0)
            {
                exit += string.Format("; Topics=[{0}]", string.Join(", ", this.topics));
            }
            return exit;
        }
    }
}
