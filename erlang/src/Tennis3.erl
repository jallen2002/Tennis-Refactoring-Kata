

-module('Tennis3').

-include("Tennis3.hrl").
-export([score/1]).

-spec score(#game{}) -> binary.
score(Game = #game{player1 = Player1, player2 = Player2}) ->
  "Love-All".
