using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace LAT.WorkflowUtilities.Numeric
{
    public class RaiseToThePower : WorkFlowActivityBase
    {
        public RaiseToThePower() : base(typeof(RaiseToThePower)) { }

        [RequiredArgument]
        [Input("Number")]
        public InArgument<double> Number { get; set; }

        [RequiredArgument]
        [Input("Power Number")]
        [Default("2")]
        public InArgument<double> PowerNumber { get; set; }

        [RequiredArgument]
        [Input("Round Decimal Places")]
        [Default("-1")]
        public InArgument<int> RoundDecimalPlaces { get; set; }

        [Output("Result")]
        public OutArgument<double> Result { get; set; }
        protected override void ExecuteCrmWorkFlowActivity(CodeActivityContext context, LocalWorkflowContext localContext)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (localContext == null)
                throw new ArgumentNullException(nameof(localContext));

            var number = Number.Get(context);
            var powerNumber = PowerNumber.Get(context);
            var roundDecimalPlaces = RoundDecimalPlaces.Get(context);

            var result = Math.Pow(number, powerNumber);

            if (roundDecimalPlaces != -1)
                result = Math.Round(result, roundDecimalPlaces);

            Result.Set(context, result);
        }
    }
}