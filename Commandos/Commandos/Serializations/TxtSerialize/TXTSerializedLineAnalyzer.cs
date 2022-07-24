using System.Text.RegularExpressions;

namespace Commandos.TxtSerialize
{
    internal class TXTSerializedLineAnalyzer
    {
        private Regex ParamPattern = new(@"<([^>]*): ([^>]{0,})>;");
        public TXTSerializedParameters GetTXTSerializedParameters(string txtSerializedLine)
        {
            TXTSerializedParameters txtSerializedParameters = new();
            txtSerializedParameters.PrimalLine = txtSerializedLine;
            foreach (Match p in ParamPattern.Matches(txtSerializedLine))
            {
                txtSerializedParameters.Add(p.Groups[1].Value, p.Groups[2].Value);
            }
            return txtSerializedParameters;

        }

    }
}
