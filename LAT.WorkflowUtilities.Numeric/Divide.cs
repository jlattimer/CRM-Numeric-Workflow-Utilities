using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace LAT.WorkflowUtilities.Numeric
{
    public class Divide : WorkFlowActivityBase
    {
        public Divide() : base(typeof(Divide)) { }

        [RequiredArgument]
        [Input("Number 1")]
        public InArgument<decimal> Number1 { get; set; }

        [RequiredArgument]
        [Input("Number 2")]
        public InArgument<decimal> Number2 { get; set; }

        [RequiredArgument]
        [Input("Round Decimal Places")]
        [Default("-1")]
        public InArgument<int> RoundDecimalPlaces { get; set; }

        [Output("Quotient")]
        public OutArgument<decimal> Quotient { get; set; }

        protected override void ExecuteCrmWorkFlowActivity(CodeActivityContext context, LocalWorkflowContext localContext)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (localContext == null)
                throw new ArgumentNullException(nameof(localContext));

            decimal number1 = Number1.Get(context);
            decimal number2 = Number2.Get(context);
            int roundDecimalPlaces = RoundDecimalPlaces.Get(context);

            if (number2 == 0)
            {
                Quotient.Set(context, 0);
                return;
            }

            decimal quotient = number1 / number2;

            if (roundDecimalPlaces != -1)
                quotient = Math.Round(quotient, roundDecimalPlaces);

            Quotient.Set(context, quotient);
        }
    }
}