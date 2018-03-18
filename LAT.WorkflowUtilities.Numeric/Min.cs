using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace LAT.WorkflowUtilities.Numeric
{
    public class Min : WorkFlowActivityBase
    {
        public Min() : base(typeof(Min)) { }

        [RequiredArgument]
        [Input("Number 1")]
        public InArgument<decimal> Number1 { get; set; }

        [RequiredArgument]
        [Input("Number 2")]
        public InArgument<decimal> Number2 { get; set; }

        [Output("Min Value")]
        public OutArgument<decimal> MinValue { get; set; }

        protected override void ExecuteCrmWorkFlowActivity(CodeActivityContext context, LocalWorkflowContext localContext)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (localContext == null)
                throw new ArgumentNullException(nameof(localContext));

            decimal number1 = Number1.Get(context);
            decimal number2 = Number2.Get(context);

            decimal minValue = number1 <= number2 ? number1 : number2;

            MinValue.Set(context, minValue);
        }
    }
}