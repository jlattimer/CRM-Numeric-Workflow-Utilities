using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace LAT.WorkflowUtilities.Numeric
{
    public class Max : WorkFlowActivityBase
    {
        public Max() : base(typeof(Max)) { }

        [RequiredArgument]
        [Input("Number 1")]
        public InArgument<decimal> Number1 { get; set; }

        [RequiredArgument]
        [Input("Number 2")]
        public InArgument<decimal> Number2 { get; set; }

        [Output("Max Value")]
        public OutArgument<decimal> MaxValue { get; set; }

        protected override void ExecuteCrmWorkFlowActivity(CodeActivityContext context, LocalWorkflowContext localContext)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (localContext == null)
                throw new ArgumentNullException(nameof(localContext));

            decimal number1 = Number1.Get(context);
            decimal number2 = Number2.Get(context);

            decimal maxValue = number1 >= number2 ? number1 : number2;

            MaxValue.Set(context, maxValue);
        }
    }
}