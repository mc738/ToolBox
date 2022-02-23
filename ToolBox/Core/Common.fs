namespace ToolBox.Core

open System

type Failure =
    { Message: string
      Exception: Exception option }