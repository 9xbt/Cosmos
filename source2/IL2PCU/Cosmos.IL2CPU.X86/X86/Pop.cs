﻿using System;
using System.Linq;

namespace Cosmos.IL2CPU.X86 {
    [OpCode("pop")]
	public class Pop: InstructionWithDestinationAndSize{
        public static void InitializeEncodingData(Instruction.InstructionData aData) {
            aData.EncodingOptions.Add(new InstructionData.InstructionEncodingOption {
                AllowedSizes = InstructionSizes.DWord | InstructionSizes.Word,
                OpCode = new byte[] { 0x58 },
                NeedsModRMByte = false,
                DestinationRegAny = true,
                DefaultSize=InstructionSize.DWord,
                ReverseRegisters=true,
                DestinationRegByte = 0
            }); // pop to register
            aData.EncodingOptions.Add(new InstructionData.InstructionEncodingOption {
                AllowedSizes =  InstructionSizes.DWord | InstructionSizes.Word,
                OpCode = new byte[]{0x8F},
                NeedsModRMByte=true,
                DestinationMemory=true,
                ReverseRegisters = true,
                DefaultSize = InstructionSize.DWord
            }); // pop to memory
        }
	}

}