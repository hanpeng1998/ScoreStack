using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreStack.ModelValidations
{
    public class QQAttribute : RegularExpressionAttribute
    {
        public QQAttribute(/*string pattern*/) :base(@"[1-9]\d{4,}")
        {

        }
        public override string FormatErrorMessage(string name)
        {
            return  "qq格式不正确";
        }
    }
}
