O teu irmão acabou de ganhar um presente novo. #portrait:narration
Ele está super feliz. Mas tu sentes um nó na barriga e fechas as mãos com força...

Eu também queria... #portrait:thought

-> minigame_puzzle_ciume

=== continue1 ===
Parabéns, reconheceste o ciúme! O ciúme aparece quando sentimos que alguém tem algo que nós também queríamos, como um presente, atenção ou carinho. #portrait:narration

-> main

=== main ===
Porque é que ele ganhou um presente e eu não? #portrait:thought

+ [Vocês gostam mais dele do que de mim, ele é o preferido!]

    Vocês gostam mais dele do que de mim, ele é o preferido! #portrait:speech_left
    
    Porque dizes isso? Vou-te contar um segredo, os pais gostam de todos os filhos da mesma forma e não há preferidos. #portrait:speech_right
    
    Hoje o teu irmão teve um presente porque estudou e teve uma boa nota no teste.
    
    Quando fores para a escola como o teu irmão e tiveres boas notas, também te podemos dar presentes.
    
    -> main
    
+ [A sério? O meu irmão tem um presente e eu não? Mas vou fingir que não me importo, não vou mostrar os meus ciúmes.]

    A sério? O meu irmão tem um presente e eu não? Mas vou fingir que não me importo, não vou mostrar os meus ciúmes. #portrait:speech_left
    
    Queres falar comigo sobre o presente do teu irmão? Acho que ficaste com um bocadinho de ciúmes #portrait:speech_right
    Ficaste? Não faz mal. Às vezs sentimos isso quando alguém tem o que nós queríamos.
    Mas devemos mostrar aos outros como nos sentimos para eles nos ajudarem a ficarmos mais felizes, não achas?
    -> main
    
+ [Hoje foi a vez do meu irmão receber um presente porque estudou muito e conseguiu uma boa nota, mas eu também recebo coisas noutras alturas.]

    Hoje foi a vez do meu irmão receber um presente porque estudou muito e conseguiu uma boa nota, mas eu também recebo coisas noutras alturas. #portrait:speech_left
    
    Isso mesmo! Cada um pode ter o seu momento e receber presentes. #portrait:speech_right
    
    O importante é ambos estarem felizes, não achas?
    -> novas_escolhas
    
=== novas_escolhas ===
+ [Acho que se ele ficar feliz, também fico feliz por ele.]
    
    Acho que se ele ficar feliz, também fico feliz por ele. #portrait:speech_left
    
    Isso é muito bonito da tua parte! Ao apoiares o teu irmão, estás a crescer e partilhar alegria. #portrait:speech_right
    -> minigame_caixa_dos_sorrisos

+ [Ainda tenho um bocadinho de ciúmes, mas já consigo entender.]

    Ainda tenho um bocadinho de ciúmes, mas já consigo entender. #portrait:speech_left
    
    É normal ainda te sentires assim, mas estás no caminho certo! Lembra-te de que também podes sentir alegria ao ver os outros felizes. #portrait:speech_right

    -> minigame_caixa_dos_sorrisos

=== continue2 ===
Parabéns! Conseguiste encontrar muitos sorrisos ao teu redor! Agora a tua caixa está cheia de alegria para partilhares com quem mais gostas. #portrait:narration

Agora já sabes, quando sentires ciúmes outra vez lembra-te: #portrait:speech_right

É normal querer o que os outros têm, mas também é bonito aprender a ficar mais feliz por eles.

O teu coração ficou apertado com ciúmes, mas conseguiste abri-lo para entender os sentimentos dos outros. De cada vez que fazes isso, o teu coração cresce! #portrait:narration

-> END

=== minigame_puzzle_ciume ===
Qual é a emoção que o João está a sentir? #portrait:narration #minigame:PuzzleCiume
-> continue1

=== minigame_caixa_dos_sorrisos ===
Minijogo Caixa dos Sorrisos #minigame:CaixaDosSorrisos
-> continue2
