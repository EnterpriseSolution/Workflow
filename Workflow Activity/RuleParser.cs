using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Workflow.Activities.Rules;

namespace SimpleRuleEditor
{  
    public class RuleParser
    {
        private const string TypeName = "System.Workflow.Activities.Rules.Parser, System.Workflow.Activities, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35";
        private Type ruleType;
        private IDictionary<string, string> substitutions;
        private RuleValidation ruleValidation;

        public RuleParser(Type ruleType, IDictionary<string, string> substitutions)
        {
            this.ruleType = ruleType;
            this.substitutions = substitutions;
            this.ruleValidation = new RuleValidation(this.ruleType, null);
        }

        public RuleExpressionCondition ParseCondition(string expression)
        {
            if (this.substitutions != null)
            {
                foreach (var key in this.substitutions.Keys)
                {
                    expression = expression.Replace(key, this.substitutions[key]);
                }
            }

            return ExecuteMethod("ParseCondition", new object[] { this.ruleValidation }, new object[] { expression }) as RuleExpressionCondition;
        }

        public List<RuleAction> ParseStatementList(string expression)
        {
            if (this.substitutions != null)
            {
                foreach (var key in this.substitutions.Keys)
                {
                    expression = expression.Replace(key, this.substitutions[key]);
                }
            }

            return ExecuteMethod("ParseStatementList", new object[] { this.ruleValidation }, new object[] { expression }) as List<RuleAction>;
        }

        private object ExecuteMethod(string name, object[] ctorParameters, object[] methodParameters)
        {
            try
            {
                var type = Type.GetType(TypeName);
                var ctor = type.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(RuleValidation) }, null);
                var instance = ctor.Invoke(ctorParameters);
                var method = instance.GetType().GetMethod(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                return method.Invoke(instance, methodParameters);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
