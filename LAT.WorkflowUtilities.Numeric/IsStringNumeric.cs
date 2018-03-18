using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace LAT.WorkflowUtilities.Numeric
{
    public class IsStringNumeric : WorkFlowActivityBase
    {
        public IsStringNumeric() : base(typeof(IsStringNumeric)) { }

        [RequiredArgument]
        [Input("Number")]
        public InArgument<string> Number { get; set; }

        [Output("Is String Numeric")]
        public OutArgument<bool> IsNumeric { get; set; }

        protected override void ExecuteCrmWorkFlowActivity(CodeActivityContext context, LocalWorkflowContext localContext)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (localContext == null)
                throw new ArgumentNullException(nameof(localContext));

            string number = Number.Get(context);

            bool isNumeric = double.TryParse(number, out double theNumber);

            IsNumeric.Set(context, isNumeric);
        }
    }
}