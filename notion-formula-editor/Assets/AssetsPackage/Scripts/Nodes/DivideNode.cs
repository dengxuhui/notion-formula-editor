using RuntimeNodeEditor;
using UnityEngine;

namespace NotionFormulaEditor.Nodes
{
    /// <summary>
    /// 除法节点
    /// </summary>
    public class DivideNode : Node
    {
        //分子
        public SocketInput numerator;

        //分母
        public SocketInput denominator;

        //结果
        public SocketOutput divideResult;

        public override void Setup()
        {
            base.Setup();
            Register(numerator);
            Register(denominator);
            Register(divideResult);
        }

        protected override void UpdateNodeValue()
        {
            base.UpdateNodeValue();
            if (numerator.TryGetConnectionOutput(out var numeratorOutput) &&
                denominator.TryGetConnectionOutput(out var denominatorOutput))
            {
                //分母不能为0
                if (numeratorOutput.IsNumber() && denominatorOutput.IsNumber() &&
                    Mathf.Abs(denominatorOutput.GetValue<float>() - float.Epsilon) > 0)
                {
                    divideResult.SetValue(numeratorOutput.GetValue<float>() / denominatorOutput.GetValue<float>());
                }
                else
                {
                    divideResult.SetValue(null);
                }
            }
            else
            {
                divideResult.SetValue(null);
            }
        }
    }
}