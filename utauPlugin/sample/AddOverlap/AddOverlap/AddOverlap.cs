using utauPlugin;

namespace AddOverlap
{
    class AddOverlap
    {
        static void Main(string[] args)
        {
            UtauPlugin utauPlugin = new UtauPlugin(args[0]);
            utauPlugin.Input();
            utauPlugin.InputVoiceBank();
            utauPlugin.InitAtParam();
            foreach (Note note in utauPlugin.note)
            {
                note.SetPre(note.GetAtPre());
                note.SetOve(note.GetAtPre());
            }
            utauPlugin.Output();
        }
    }
}
