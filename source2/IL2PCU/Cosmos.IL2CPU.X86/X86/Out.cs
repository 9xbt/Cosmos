﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cosmos.IL2CPU.X86 {
    [OpCode("out")]
    public class Out : InstructionWithDestinationAndSize {
        public static void InitializeEncodingData(Instruction.InstructionData aData) {
            aData.EncodingOptions.Add(new InstructionData.InstructionEncodingOption {
                OpCode = new byte[] { 0xEE },
                OperandSizeByte=0,
                DestinationReg=Registers.AL,
                DefaultSize = InstructionSize.Byte
            }); // fixed port (register)
        }

        public override void WriteText( Cosmos.IL2CPU.Assembler aAssembler, System.IO.TextWriter aOutput )
        {
            aOutput.Write(mMnemonic);
            aOutput.Write(" DX, ");
            aOutput.Write(this.GetDestinationAsString());
        }
	}
}