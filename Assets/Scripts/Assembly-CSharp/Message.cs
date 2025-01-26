using System.Diagnostics;
using System.IO;

public class Message
{
    public sbyte command;

    private myReader dis;

    private myWriter dos;

    public Message(int command, params string[] type)
    {

        string filePath = "E:\\log.txt";
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            if (type != null && type.Length > 0)
            {
                writer.WriteLine("Client Call 1: [" + command + "]" + " Types: " + string.Join(", ", type));
            }
            else
            {
                writer.WriteLine("Client Call 1: [" + command + "]");
            }
        }

        //UnityEngine.Debug.LogError("Client Call 1: [" + command + "]");

        this.command = (sbyte)command;
        dos = new myWriter();
    }

    public Message()
    {
        dos = new myWriter();
    }

    public Message(sbyte command, params string[] type)
    {
        string filePath = "E:\\log.txt";
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            if (type != null && type.Length > 0)
            {
                writer.WriteLine("Client Call 2: [" + command + "]" + " Types: " + string.Join(", ", type));
            }
            else
            {
                writer.WriteLine("Client Call 2: [" + command + "]");
            }
        }

        //UnityEngine.Debug.LogError("Client Call 2: [" + command + "]");

        this.command = command;
        dos = new myWriter();
    }


    public Message(sbyte command, sbyte[] data)
    {
        this.command = command;
        dis = new myReader(data);
    }

    public sbyte[] getData()
    {
        return dos.getData();
    }

    public myReader reader()
    {
        return dis;
    }

    public myWriter writer()
    {
        return dos;
    }

    public int readInt3Byte()
    {
        return dis.readInt();
    }

    public void cleanup()
    {
    }
}
