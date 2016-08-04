namespace TDDMicroExercises.TurnTicketDispenser
{
    public class TicketDispenser
    {
        ITurnNumberSequence _turnNumberSequence;

        public TicketDispenser() : this(new TurnNumberSequence())
        {
            
        }

        public TicketDispenser(ITurnNumberSequence turnNumberSequence)
        {
            _turnNumberSequence = turnNumberSequence;
        }

        public TurnTicket GetTurnTicket()
        {
            int newTurnNumber = _turnNumberSequence.GetNextTurnNumber();
            var newTurnTicket = new TurnTicket(newTurnNumber);

            return newTurnTicket;
        }
    }
}
