using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageBroker
{
    public MonoBehaviour sender { get; private set; }
    public int id { get; private set; }
    public System.Object data { get; private set; }

    public MessageBroker(MonoBehaviour sender, int id, System.Object data)
    {
        this.sender = sender;
        this.id = id;
        this.data = data;
    }

    public static MessageBroker Create(MonoBehaviour sender, int id, System.Object data)
    {
        return new MessageBroker(sender,id,data);
    }
}
