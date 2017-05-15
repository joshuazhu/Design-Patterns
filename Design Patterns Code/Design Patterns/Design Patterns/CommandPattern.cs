using System;
using System.Collections.Generic;
using System.Text;
using BuilderPattern;
using TemplateMethodPattern;

namespace CommandPattern
{
    /*
     * Receiver 
     */
    public class Document
    {
        private List<string> _textArray = new List<string>();

        public void Write(string text)
        {
            _textArray.Add(text);
        }
        public void Erase(string text)
        {
            _textArray.Remove(text);
        }
        public void Erase(int textLevel)
        {
            _textArray.RemoveAt(textLevel);
        }
        public string ReadDocument()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (string text in _textArray)
                sb.Append(text);
            return sb.ToString();
        }
    }

    /*
     * Command
     */
    public abstract class Command
    {
        abstract public void Redo();
        abstract public void Undo();
    }

    public class DocumentEditCommand : Command
    {
        private Document _editableDoc;

        //store the current state
        private string _text;

        public DocumentEditCommand(Document doc, string text)
        {
            _editableDoc = doc;
            _text = text;
            _editableDoc.Write(_text);
        }

        public override void Redo()
        {
            _editableDoc.Write(_text);
        }

        public override void Undo()
        {
            _editableDoc.Erase(_text);
        }
    }

    /*
     * Invoker
     */
    public class DocumentInvoker
    {
        private List<Command> _commands = new List<Command>();
        private Document _doc = new Document();

        public void Redo(int level)
        {
            Console.WriteLine("---- Redo {0} level ", level);
            ((Command)_commands[level]).Redo();
        }

        public void Undo(int level)
        {
            Console.WriteLine("---- Undo {0} level ", level);
            ((Command)_commands[level]).Undo();
        }

        public void Write(string text)
        {
            DocumentEditCommand cmd = new
                DocumentEditCommand(_doc, text);
            _commands.Add(cmd);
        }

        public void Read()
        {
            Console.WriteLine(_doc.ReadDocument());
        }
    }

    public class CommandPatternRunner : IPatterRunner
    {
        public void RunPattern()
        {
            DocumentInvoker instance = new DocumentInvoker();
            instance.Write("This is the original text.");
            instance.Write(" Here is some other text.");
            instance.Read();
            instance.Undo(1);
            instance.Read();
            instance.Redo(1);
            instance.Read();
            instance.Write(" And a little more text.");
            instance.Read();
            instance.Undo(2);
            instance.Read();
            instance.Redo(2);
            instance.Read();
            instance.Undo(1);
            instance.Read();
        }
    }
}
