﻿Imports Microsoft.AspNetCore.Mvc.RazorPages
Imports System

Public Class BaseClass
    Private ReadOnly Property Prop As Integer
        Get
            Return 42
        End Get
    End Property
End Class

Public Class SubClass       ' Noncompliant - not derived from any special base class
    Inherits BaseClass
End Class

MustInherit Class AbstractBaseWithAbstractMethods
    Public MustOverride Sub AbstractMethod()
End Class

MustInherit Class AbstractBaseWithoutAbstractMethods
    Public Overridable Sub DefaultMethod()
    End Sub
End Class

Class NoImplementation       ' Error - abstract methods should be implemented
    Inherits AbstractBaseWithAbstractMethods
End Class

Class DefaultImplementation  ' Compliant - the class will use the default implementation of DefaultMethod
    Inherits AbstractBaseWithoutAbstractMethods
End Class

Public Class EmptyPageModel ' Compliant - an empty PageModel can be fully functional, the VB code can be in the vbhtml file
    Inherits PageModel
End Class

Public Class CustomException ' Compliant - empty exception classes are allowed, the name of the class already provides information
    Inherits Exception
End Class