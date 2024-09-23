using System;
using System.Collections.Generic;
using Features.FiniteStateMachine;
using Features.FiniteStateMachine.Interfaces;
using Features.GameStateMachine.States;

namespace Features.GameStateMachine
{
    public class GameplayStateMachine : BaseStateMachine
    {
        public GameplayStateMachine() : base(new Dictionary<Type, IState>())
        {
            States.Add(typeof(InitState), new InitState(this));

            States.Add(typeof(GameloopState), new GameloopState());

            States.Add(typeof(EndLoseState), new EndLoseState());

            States.Add(typeof(EndWinState), new EndWinState());
        }
    }
}