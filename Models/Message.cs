namespace AP2_ex2.Models
{
    public class Message
    {
        public Message(string msgBody)
        {
            MessageBody = msgBody;  
            Created = DateTime.Now;
        }
        public string MessageBody { get; set; }

        public DateTime Created { get; set; }  
        
    }
   
}
