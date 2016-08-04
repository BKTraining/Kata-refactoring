using NUnit.Framework;
namespace TDDMicroExercises.TurnTicketDispenser.Tests
{
    [TestFixture]
    class TurnTicketDispenserTest
    {
        [Test]
        public void turnTicketDispenser_should_samedispenser_send_a_ticker_with_greater_number_than_previous_ticket()
        {
            TicketDispenser ticketDispenser = new TicketDispenser();
            TurnTicket ticket = ticketDispenser.GetTurnTicket();
            TurnTicket ticket2 = ticketDispenser.GetTurnTicket();
            Assert.Greater(ticket2.TurnNumber, ticket.TurnNumber);
        }

        [Test]
        public void turnTicketDispenser_should_seconddispenser_send_a_ticker_with_greater_number_than_previous_ticket_in_first_dispenser()
        {
            TicketDispenser ticketDispenser = new TicketDispenser();
            TurnTicket ticket = ticketDispenser.GetTurnTicket();
            TicketDispenser ticketDispenser2 = new TicketDispenser();
            TurnTicket ticket2 = ticketDispenser2.GetTurnTicket();
            Assert.Greater(ticket2.TurnNumber, ticket.TurnNumber);
        }

    }
}
