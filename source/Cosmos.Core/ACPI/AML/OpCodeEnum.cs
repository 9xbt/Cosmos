﻿namespace ACPILib.AML
{
	public enum OpCodeEnum : ushort
	{
		Unknown = 0xFFFF,

		Zero = 0x00,
		One = 0x01,
		Alias = 0x06,
		Name = 0x08,
		Byte = 0x0a,
		Word = 0x0b,
		DWord = 0x0c,
		String = 0x0d,
		QWord = 0x0e,
		Scope = 0x10,
		Buffer = 0x11,
		Package = 0x12,
		VariablePackage = 0x13,
		Method = 0x14,
		External = 0x15,
		DualNamePrefix = 0x2e,
		MultiNamePrefix = 0x2f,
		ExtendedPrefix = 0x5b,
		RootPrefix = 0x5c,
		ParentPrefix = 0x5e,
		FirstLocal = 0x60,
		Local0 = 0x60,
		Local1 = 0x61,
		Local2 = 0x62,
		Local3 = 0x63,
		Local4 = 0x64,
		Local5 = 0x65,
		Local6 = 0x66,
		Local7 = 0x67,
		FirstArg = 0x68,
		Arg0 = 0x68,
		Arg1 = 0x69,
		Arg2 = 0x6a,
		Arg3 = 0x6b,
		Arg4 = 0x6c,
		Arg5 = 0x6d,
		Arg6 = 0x6e,
		Store = 0x70,
		ReferenceOf = 0x71,
		Add = 0x72,
		Concatenate = 0x73,
		Subtract = 0x74,
		Increment = 0x75,
		Decrement = 0x76,
		Multiply = 0x77,
		Divide = 0x78,
		ShiftLeft = 0x79,
		ShiftRight = 0x7a,
		BitAnd = 0x7b,
		BitNand = 0x7c,
		BitOr = 0x7d,
		BitNor = 0x7e,
		BitXor = 0x7f,
		BitNot = 0x80,
		FindSetLeftBit = 0x81,
		FindSetRightBit = 0x82,
		DereferenceOf = 0x83,
		ConcatenateTemplate = 0x84,
		Mod = 0x85,
		Notify = 0x86,
		SizeOf = 0x87,
		Index = 0x88,
		Match = 0x89,
		CreateDWordField = 0x8a,
		CreateWordField = 0x8b,
		CreateByteField = 0x8c,
		CreateBitField = 0x8d,
		ObjectType = 0x8e,
		CreateQWordField = 0x8f,
		LogicalAnd = 0x90,
		LogicalOr = 0x91,
		LogicalNot = 0x92,
		LogicalEqual = 0x93,
		LogicalGreater = 0x94,
		LogicalLess = 0x95,
		ToBuffer = 0x96,
		ToDecimalString = 0x97,
		ToHexString = 0x98,
		ToInteger = 0x99,
		ToString = 0x9c,
		CopyObject = 0x9d,
		Mid = 0x9e,
		Continue = 0x9f,
		If = 0xa0,
		Else = 0xa1,
		While = 0xa2,
		NoOp = 0xa3,
		Return = 0xa4,
		Break = 0xa5,
		Comment = 0xa9,
		Breakpoint = 0xcc,
		Ones = 0xff,

		LogicalGreaterEqual = 0x9295,
		LogicalLessEqual = 0x9294,
		LogicalNotEqual = 0x9293,

		ExtendedOpcode = 0x5b00,     //Prefix

		Mutex = 0x5b01,
		Event = 0x5b02,
		ShiftRightBit = 0x5b10,
		ShiftLeftBit = 0x5b11,
		ConditionalReferenceOf = 0x5b12,
		CreateField = 0x5b13,
		LoadTable = 0x5b1f,
		Load = 0x5b20,
		Stall = 0x5b21,
		Sleep = 0x5b22,
		Acquire = 0x5b23,
		Signal = 0x5b24,
		Wait = 0x5b25,
		Reset = 0x5b26,
		Release = 0x5b27,
		FromBCD = 0x5b28,
		ToBCD = 0x5b29,
		Unload = 0x5b2a,
		Revision = 0x5b30,
		Debug = 0x5b31,
		Fatal = 0x5b32,
		Timer = 0x5b33,
		Region = 0x5b80,
		Field = 0x5b81,
		Device = 0x5b82,
		Processor = 0x5b83,
		PowerResource = 0x5b84,
		ThermalZone = 0x5b85,
		IndexField = 0x5b86,
		BankField = 0x5b87,
		DataRegion = 0x5b88,

		FieldOffset = 0x00,
		FieldAccess = 0x01,
		FieldConnection = 0x02,
		FieldExternalAccess = 0x03,

		NamePath = 0x002d,
		NamedField = 0x0030,
		ReservedField = 0x0031,
		AccessField = 0x0032,
		ByteList = 0x0033,
		MethodCall = 0x0035,
		ReturnValue = 0x0036,
		EvalSubtree = 0x0037,
		Connection = 0x0038,
		ExternalAccessField = 0x0039,
	}
}
