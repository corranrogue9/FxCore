using System;

namespace Fx.Concurrency
{
    public interface IInstruction
    {
        bool IsSharedMemoryAccess { get; }
    }

    public class Instruction : IInstruction
    {
        private readonly IInstruction instruction;

        private readonly int thread;

        public Instruction(IInstruction instruction, int thread)
        {
            this.instruction = instruction;
            this.thread = thread;
        }

        public bool IsSharedMemoryAccess
        {
            get
            {
                return this.instruction.IsSharedMemoryAccess;
            }
        }

        public override string ToString()
        {
            return $"{this.instruction.ToString()} Thread: {this.thread}";
        }
    }

    public class IntInstruction : IInstruction
    {
        public int Value { get; set; }

        public bool IsSharedMemoryAccess
        {
            get
            {
                return this.Value % 2 == 0;
            }
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
