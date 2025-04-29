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
-> minigame_caixa_dos_sorrisos

=== continue2 ===
Parabéns! Aprendeste a reconhecer os ingredientes no teu prato e a experimentar novos sabores. Estás no caminho certo para ser um verdadeiro chef! #portrait:narration

Vês? Experimentar não foi assim tão mau! #portrait:speech_right

Ainda não adoro, mas consegui comer um pouco. #portrait:speech_left

E isso já é um grande passo. O teu paladar pode mudar com o tempo! #portrait:speech_right

Explorar novos sabores é uma aventura! Mesmo que ainda não adores, sabes que esses alimentos fazem bem à tua saúde e vão ajudar-te a ser ainda mais forte e saudável. #portrait:narration

-> END

=== minigame_puzzle_ciume ===
Qual é a emoção que o João está a sentir? #portrait:narration #minigame:PuzzleCiume
-> continue1

=== minigame_caixa_dos_sorrisos ===
Minijogo Caixa dos Sorrisos #minigame:CaixaDosSorrisos
-> continue2
