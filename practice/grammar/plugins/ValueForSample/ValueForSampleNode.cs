#region usings
using System;
using System.ComponentModel.Composition;

using VVVV.PluginInterfaces.V1;
using VVVV.PluginInterfaces.V2;
using VVVV.Utils.VColor;
using VVVV.Utils.VMath;

using VVVV.Core.Logging;
#endregion usings

namespace VVVV.Nodes
{
	#region PluginInfo
	[PluginInfo(Name = "ForSample", Category = "Value", Help = "Basic template with one value in/out", Tags = "")]
	#endregion PluginInfo
	public class ValueForSampleNode : IPluginEvaluate
	{
		#region fields & pins
		[Input("Min", DefaultValue = 1.0)]
        public ISpread<int>  Min;

		[Input("Max", DefaultValue = 1.0)]
        public ISpread<int>  Max;

		[Output("Output")]
        public ISpread<int> SumOut;

		[Import()]
        public ILogger FLogger;
		#endregion fields & pins
 
		//called when data for any output pin is requested
		public void Evaluate(int SpreadMax)
		{ 
			int tmpOut = 0;
			for(int i = Min[0]; i<Max[0]; i++)
			{
				tmpOut = tmpOut + i;
			}
			
			SumOut[0] = tmpOut;
				 
			//FLogger.Log(LogType.Debug, "hi tty!");
		}
	}
}

