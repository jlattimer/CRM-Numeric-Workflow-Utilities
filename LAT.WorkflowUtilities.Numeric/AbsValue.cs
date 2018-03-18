using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace LAT.WorkflowUtilities.Numeric
{
    public class AbsValue : WorkFlowActivityBase
    {
        public AbsValue() : base(typeof(AbsValue)) { }

        [RequiredArgument]
        [Input("Number")]
        public InArgument<double> Number { get; set; }

        [Output("Absolute Value")]
        public OutArgument<double> AbsoluteValue { get; set; }

        protected override void ExecuteCrmWorkFlowActivity(CodeActivityContext context, LocalWorkflowContext localContext)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (localContext == null)
                throw new ArgumentNullException(nameof(localContext));

            double number = Number.Get(context);

            double absoluteValue = Math.Abs(number);

            AbsoluteValue.Set(context, absoluteValue);
        }
    }
}