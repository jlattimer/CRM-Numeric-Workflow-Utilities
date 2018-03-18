using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace LAT.WorkflowUtilities.Numeric
{
    public class Truncate : WorkFlowActivityBase
    {
        public Truncate() : base(typeof(Truncate)) { }

        [RequiredArgument]
        [Input("Number To Truncate")]
        public InArgument<decimal> NumberToTruncate { get; set; }

        [RequiredArgument]
        [Input("Decimal Places")]
        public InArgument<int> DecimalPlaces { get; set; }

        [Output("Truncated Number")]
        public OutArgument<decimal> TruncatedNumber { get; set; }

        protected override void ExecuteCrmWorkFlowActivity(CodeActivityContext context, LocalWorkflowContext localContext)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (localContext == null)
                throw new ArgumentNullException(nameof(localContext));

            decimal numberToTruncate = NumberToTruncate.Get(context);
            int decimalPlaces = DecimalPlaces.Get(context);

            if (decimalPlaces < 0)
                decimalPlaces = 0;

            decimal step = (decimal)Math.Pow(10, decimalPlaces);
            int temp = (int)Math.Truncate(step * numberToTruncate);

            decimal truncatedNumber = temp / step;

            TruncatedNumber.Set(context, truncatedNumber);
        }
    }
}