using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace LAT.WorkflowUtilities.Numeric
{
    public class ToDecimal : WorkFlowActivityBase
    {
        public ToDecimal() : base(typeof(ToDecimal)) { }

        [RequiredArgument]
        [Input("Text To Convert")]
        public InArgument<string> TextToConvert { get; set; }

        [Output("Converted Number")]
        public OutArgument<decimal> ConvertedNumber { get; set; }

        [Output("Is Valid Decimal")]
        public OutArgument<bool> IsValid { get; set; }

        protected override void ExecuteCrmWorkFlowActivity(CodeActivityContext context, LocalWorkflowContext localContext)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (localContext == null)
                throw new ArgumentNullException(nameof(localContext));

            string textToConvert = TextToConvert.Get(context);

            if (string.IsNullOrEmpty(textToConvert))
            {
                IsValid.Set(context, false);
                return;
            }

            bool isNumber = decimal.TryParse(textToConvert, out var convertedNumber);

            if (isNumber)
            {
                ConvertedNumber.Set(context, convertedNumber);
                IsValid.Set(context, true);
            }
            else
                IsValid.Set(context, false);
        }
    }
}