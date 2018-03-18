using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace LAT.WorkflowUtilities.Numeric
{
    public class Round : WorkFlowActivityBase
    {
        public Round() : base(typeof(Round)) { }

        [RequiredArgument]
        [Input("Number To Round")]
        public InArgument<decimal> NumberToRound { get; set; }

        [RequiredArgument]
        [Input("Decimal Places")]
        public InArgument<int> DecimalPlaces { get; set; }

        [Output("Rounded Number")]
        public OutArgument<decimal> RoundedNumber { get; set; }


        protected override void ExecuteCrmWorkFlowActivity(CodeActivityContext context, LocalWorkflowContext localContext)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (localContext == null)
                throw new ArgumentNullException(nameof(localContext));

            decimal numberToRound = NumberToRound.Get(context);
            int decimalPlaces = DecimalPlaces.Get(context);

            if (decimalPlaces < 0)
                decimalPlaces = 0;

            decimal roundedNumber = Math.Round(numberToRound, decimalPlaces);

            RoundedNumber.Set(context, roundedNumber);
        }
    }
}