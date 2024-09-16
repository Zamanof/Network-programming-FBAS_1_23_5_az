﻿namespace NP_03._TCP_Task_Manager_Listener;

internal class Command
{
    public const string processList = "PROCLIST";
    public const string kill = "KILL";
    public const string run = "RUN";
    public string? Text { get; set; }
    public string? Param { get; set; }
}
