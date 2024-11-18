﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'This class was auto-generated by the StronglyTypedResourceBuilder
    'class via a tool like ResGen or Visual Studio.
    'To add or remove a member, edit your .ResX file then rerun ResGen
    'with the /str option, or rebuild your VS project.
    '''<summary>
    '''  A strongly-typed resource class, for looking up localized strings, etc.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.Microsoft.VisualBasic.HideModuleNameAttribute()>  _
    Friend Module Resources
        
        Private resourceMan As Global.System.Resources.ResourceManager
        
        Private resourceCulture As Global.System.Globalization.CultureInfo
        
        '''<summary>
        '''  Returns the cached ResourceManager instance used by this class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("EquipmentMappingTool.Resources", GetType(Resources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Overrides the current thread's CurrentUICulture property for all
        '''  resource lookups using this strongly typed resource class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to CREATE TABLE Config (
        '''	StartMaximized INTEGER DEFAULT 0,
        '''	LastMapPath TEXT DEFAULT &apos;&apos;,
        '''	ExpireDays INTEGER DEFAULT 7,
        '''	ExpiredCellForecolor INTEGER
        ''');
        '''
        '''CREATE INDEX Cfg_Key ON Config (Key);
        '''CREATE INDEX Cfg_Group ON Config (Group);.
        '''</summary>
        Friend ReadOnly Property ConfigSetupSQL() As String
            Get
                Return ResourceManager.GetString("ConfigSetupSQL", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Icon similar to (Icon).
        '''</summary>
        Friend ReadOnly Property GridMap() As System.Drawing.Icon
            Get
                Dim obj As Object = ResourceManager.GetObject("GridMap", resourceCulture)
                Return CType(obj,System.Drawing.Icon)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to CREATE TABLE Map (
        '''	Name TEXT NOT NULL,
        '''	Height INTEGER NOT NULL,
        '''	Width INTEGER NOT NULL
        ''');
        '''
        '''CREATE TABLE Area (
        '''	ID INTEGER PRIMARY KEY AUTOINCREMENT,
        '''	Name TEXT NOT NULL,
        '''	Color TEXT NOT NULL,
        '''	CanHoldItems INTEGER NOT NULL DEFAULT 1
        ''');
        '''
        '''CREATE TABLE Layout (
        '''	ID INTEGER PRIMARY KEY AUTOINCREMENT,
        '''	Row INTEGER NOT NULL,
        '''	Column INTEGER NOT NULL,
        '''	AreaID INTEGER NOT NULL
        ''');
        '''
        '''CREATE TABLE Item (
        '''	ID TEXT PRIMARY KEY UNIQUE,
        '''	Name TEXT NOT NULL,
        '''	Row INTEGER NOT NULL,
        '''	Column INTEGER [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property MapInitSQL() As String
            Get
                Return ResourceManager.GetString("MapInitSQL", resourceCulture)
            End Get
        End Property
    End Module
End Namespace
