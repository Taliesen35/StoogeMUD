using StoogeWorld.Utiltities;

namespace StoogeWorld.Things.Mobs.NPCs
{
	public class Npc : Mobile
	{
		public int MovePulse { get; set; }
		public int[] WalkPath { get; set; }


		public void Pulse()
		{
			Move(GetPulseDirection());
		}

		public Direction GetPulseDirection()
		{
			return Direction.Down;
		}
	}
}
