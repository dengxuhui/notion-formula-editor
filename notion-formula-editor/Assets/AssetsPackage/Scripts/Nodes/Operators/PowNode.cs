using RuntimeNodeEditor;
using UnityEngine;

namespace NotionFormulaEditor.Nodes
{
    /// <summary>
    /// 指数节点
    /// </summary>
    public class PowNode : Node
    {
        //底数
        public SocketInput baseNumber;

        //指数
        public SocketInput exponent;

        //结果
        public SocketOutput powResult;

        public override void Setup()
        {
            base.Setup();
            Register(baseNumber);
            Register(exponent);
            Register(powResult);
        }

        protected override void UpdateNodeValue()
        {
            base.UpdateNodeValue();
            if (baseNumber.TryGetConnectionOutput(out var baseNumberOutput) &&
                exponent.TryGetConnectionOutput(out var exponentOutput))
            {
                if (baseNumberOutput.IsNumber() && exponentOutput.IsNumber())
                {
                    powResult.SetValue(Mathf.Pow(baseNumberOutput.GetValue<float>(), exponentOutput.GetValue<float>()));
                }
                else
                {
                    powResult.SetValue(null);
                }
            }
            else
            {
                powResult.SetValue(null);
            }
        }
    }
}