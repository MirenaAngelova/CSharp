using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BangaloreUniversityLearningSystem.Infrastructure;

namespace BangaloreUniversityLearningSystem.Test
{
    public class MockView : View
    {
        public MockView(object model) : base(model)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            viewResult.Append(this.Model as string);
        }
    }
}
