using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section3
{
	class Vertax
	{
		public List<Vertax> edges = new List<Vertax>();

		public List<Vertax> CreateGraph()
		{
			List<Vertax> v = new List<Vertax>(6)
			{
				new Vertax(),
				new Vertax(),
				new Vertax(),
				new Vertax(),
				new Vertax(),
				new Vertax()
			};

			v[0].edges.Add(v[1]);
			v[0].edges.Add(v[3]);

			v[1].edges.Add(v[0]);
			v[1].edges.Add(v[2]);
			v[1].edges.Add(v[3]);

			v[3].edges.Add(v[4]);

			v[5].edges.Add(v[4]);

			return v;
		}
	}
}
