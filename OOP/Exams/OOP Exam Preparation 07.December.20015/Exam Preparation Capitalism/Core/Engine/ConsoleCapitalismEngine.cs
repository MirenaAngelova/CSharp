using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam_Preparation_Capitalism.Core.Commands;
using Exam_Preparation_Capitalism.Interfaces;

namespace Exam_Preparation_Capitalism.Core.Engine
{
     class ConsoleCapitalismEngine:IEngine
    {
        private readonly IDatabase db;

        public ConsoleCapitalismEngine(IDatabase db)
        {
            this.db = db;
        }

        public void Run()
        {
            IExecutable command = null;
            string line = Console.ReadLine();
            while (line != "end")
            {
                string[] token = line.Split();
                switch (token[0])
                {
                    case "create-company":
                        command = new CreateCompanyCommand(
                            db,
                            token[1],
                            token[2],
                            token[3],
                            decimal.Parse(token[4]
                            ));
                        break;
                    case "create-department":
                        command = new CreateDepartmentCommand(
                            )
                }
                line = Console.ReadLine();
            }
        }
    }
}
