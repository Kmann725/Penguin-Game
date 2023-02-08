/*
 * Gerard Lamoureux
 * Pickup
 * Team Project 1
 * Interface for Subjects of Observers
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerSubject
{
    void RegisterPlayerObserver(IPlayerObserver observer);
    void RemovePlayerObserver(IPlayerObserver observer);
    void NotifyPlayerObservers();
}
