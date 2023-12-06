using medcenter_backend.Models;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;

namespace medcenter_backend
{
	public class Common
	{
		public static List<Answer> GetAnswer()
		{
			List<Answer> list = new List<Answer>();
			list.Add(new Answer() { ID = 1, Name = "Excellent", Css = "check w3" });
            list.Add(new Answer() { ID = 2, Name = "Good", Css = "check w3ls" });
            list.Add(new Answer() { ID = 3, Name = "Neutral", Css = "check wthree" });
            list.Add(new Answer() { ID = 4, Name = "Poor", Css = "check w3_agileits" });
			return list;
        }
	}
}
