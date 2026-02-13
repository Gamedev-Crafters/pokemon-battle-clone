### Documentation
- [Damage - Bulbapedia](https://bulbapedia.bulbagarden.net/wiki/Damage)
- [Move Power - Bulbapedia](https://bulbapedia.bulbagarden.net/wiki/Power)

### Formula

Unless otherwise specified, all divisions and multiplication past the initial base damage calculation are rounded to the nearest integer if the results is not an integer (rounding down at 0.5).
$$
Damage =
\left(
	\frac
		{
			\left(
				\frac{2 \times Level}{5} + 2
			\right)
			\times Power \times \frac{A}{D}
		}
		{50} + 2
\right)
\times Targets \times Weather \times Critical \times random \times STAB \times Type \times Burn \times other
$$

- *Level* is the level of the attacking pokemon.
- *A* is the effective Attack stat of the attacking Pokémon if the used move is a physical move, or the effective Special Attack stat of the attacking Pokémon if the used moved is a special move (ignoring negative stat stages for a critical hit).
- *D* is the effective Defense stat of the target if the used move is a physical move or a special move that uses the target's Defense stat, or the effective Special Defense of the target if the used move is an other special move (ignoring positive stat stages for a critical hit).
- *Power* is the effective power of the used move.
- *Targets* is 0.75 (0.5 in Battle Royals) if the move has more than one target when the move is executed, and 1 otherwise.
- *Weather* is 1.5 if a Water-type move is being used during rain or a Fire-type move or Hydro Steam during harsh sunlight, and 0.5 if a Water-type move (besides Hydro Steam) is used during harsh sunlight or a Fire-type move during rain, and 1 otherwise or if any Pokémon on the field have the Ability Cloud Nine or Air Lock.
- *Critical*  is 1.5 (2 in Generation V) for a critical hit, and 1 otherwise. Decimals are rounded down to the nearest integer. It is always 1 if the target's Ability is Battle Armor or Shell Armor or if the target is under the effect of Lucky Chant.
- *random* is a random factor. Namely, it is recognized as a multiplication from a random integer between 85 and 100, inclusive, then divided by 100.
- *STAB* is the same-type attack bonus. This is equal to 1.5 if the move's type matches any of the user's types, 2 if the user of the move additionally has Adaptability, and 1 otherwise or if the attacker and/or used move is typeless.
- *Type* is the type effectiveness. This can be 0.125, 0.25, 0.5 (not very effective); 1 (normally effective); 2, 4, or 8 (super effective), depending on both the move's and target's types.
- *Burn* is 0.5 if the attacker is burned, its Ability is not Guts, and the used move is a physical move (other than Facade from Generation VI onward), and 1 otherwise.
- *other* ...