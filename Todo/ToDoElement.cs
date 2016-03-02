using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Todo
{
	[Serializable]
	public class ToDoElement
	{
		private string _datum;
    private string _text;
    private int _prio;

    public void save(string FileName)
    {
      using( var writer = new System.IO.StreamWriter(FileName) )
      {
        var serializer = new XmlSerializer(this.GetType());
        serializer.Serialize(writer, this);
        writer.Flush();
      }
    }

    public string datum
    {
      get { return _datum; }
      set { _datum = value; }
    }

    public string text
    {
      get { return _text; }
      set { _text = value; }
    }

		public int prio
    {
      get { return _prio; }
      set { _prio = value; }
    }
  }
}
