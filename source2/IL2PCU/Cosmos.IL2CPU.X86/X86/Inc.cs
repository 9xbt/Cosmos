﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cosmos.IL2CPU.X86 {
    [OpCode("inc")]
    public class Inc : InstructionWithDestinationAndSize {
        public static void InitializeEncodingData(Instruction.InstructionData aData) {
            aData.EncodingOptions.Add(new InstructionData.InstructionEncodingOption {
                OpCode=new byte[] {0x40},
                DestinationRegAny=true,
                DestinationRegByte=0,
                AllowedSizes = InstructionSizes.DWord | InstructionSizes.Word
            }); // reg (alt)
            aData.EncodingOptions.Add(new InstructionData.InstructionEncodingOption {
                OpCode = new byte[] { 0xFE },
                DestinationRegAny = true,
                NeedsModRMByte=true,
                InitialModRMByteValue=0xC0,
                ReverseRegisters=true,
                OperandSizeByte=0
            }); // reg
            aData.EncodingOptions.Add(new InstructionData.InstructionEncodingOption {
                OpCode = new byte[] { 0xFE },
                DestinationMemory=true,
                NeedsModRMByte = true,
                ReverseRegisters = true,
                OperandSizeByte = 0
            }); // memory
        }
    }
}
