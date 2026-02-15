# Calculate Stats

### Documentation
- [Stats - Bulbapedia ](https://bulbapedia.bulbagarden.net/wiki/Stat)
- [Nature - Bulbapedia](https://bulbapedia.bulbagarden.net/wiki/Nature)

### Formulas
$$
PS =
\left\lfloor
\frac
	{( 2 \times Base + IV + \left\lfloor\frac{EV}{4}\right\rfloor \times Level)}
	{100}
\right\rfloor
+ Level + 10
$$
$$
OtherStat =
\left\lfloor
	\left(\left\lfloor
		\frac
			{(2 \times Base + IV + \left\lfloor\frac{EV}{4}\right\rfloor) \times Level}
			{100}
	\right\rfloor
	+ 5 \right) \times Nature
\right\rfloor
$$

# Stats modifiers

### Documentation
- [Stats modifiers - Bulbapedia](https://bulbapedia.bulbagarden.net/wiki/Stat_modifier)

### Formulas

```
numerator = 0
denominator = 0

if (boostLevel > 0) numerator = boost
else if (boostLevel < 0) denominator = boost * -1

boost = ( 2 + numerator ) / ( 2 + denominator )
```

