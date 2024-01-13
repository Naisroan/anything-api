using System.Reflection;

namespace anything_api;

internal class PresentationAssemblyReference
{
    internal static readonly Assembly Assembly = typeof(PresentationAssemblyReference).Assembly;
}