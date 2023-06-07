using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security;
using UnityEngine;

class PathAttribute
{
    protected string nameof { get; set; }
    protected string description { get; set; }
    protected string content { get; set; }

    public PathAttribute(string __nameof, string __description, string __content)
    {
        this.nameof = __nameof;
        this.description = __description;
        this.content = __content;
    }
}

class Path : PathAttribute
{
    private string resources_path;

    public Path(string __nameof, string __description, string __content, string __resources_path)
        : base(__nameof, __description, __content)
    {
        this.resources_path = __resources_path;
    }

}
