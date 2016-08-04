namespace TDDMicroExercises.TurnTicketDispenser
{
    public class TurnNumberSequence : ITurnNumberSequence
    {
        private static TurnNumberSequence myTurnSequence = new TurnNumberSequence();

        private int _turnNumber = 0;

        public int GetNextTurnNumber()
        {
            return myTurnSequence._turnNumber++;
        }
    }
}
