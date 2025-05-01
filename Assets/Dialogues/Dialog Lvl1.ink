É hora de dormir, mas sentes um frio na barriga ao apagar as luzes. #portrait:narration 
O quarto parece cheio de sombras estranhas e barulhos esquisitos… #show:Darkness #show:Monsters #animation:Child_afraid

-> minigame_puzzle_medo

=== continue1 ===
Parabéns, reconheceste o medo! O medo aparece quando achamos que algo nos pode fazer mal, mesmo que não seja de verdade. #portrait:narration

Está tudo bem? #portrait:speech_right #speaker:Mother #animation:Mother_smiling #hide:Darkness #hide:Monsters

-> main

=== main ===
E se tiver um monstro no meu quarto? #portrait:thought #animation:Child_afraid #animation:Mother_serious

+ [Não quero apagar a luz, posso dormir com ela acesa?]
    Não quero apagar a luz, posso dormir com ela acesa? #portrait:speech_left #animation:Child_worried
    Tens a certeza? #portrait:speech_right
    -> main
+ [E se ele estiver escondido e só sair quando eu fechar os olhos?]
    E se ele estiver escondido e só sair quando eu fechar os olhos? #portrait:speech_left #animation:Child_worried
    Assim não vais conseguir dormir. #portrait:speech_right
    -> main
    
+ [Estou com medo, mas sei que é a minha imaginação.]
    Estou com medo, mas sei que é a minha imaginação. #portrait:speech_left #animation:Child_serious
    Vamos ver o que é. #portrait:speech_right
    -> minigame_lanterna_da_coragem

=== continue2 ===
Parabéns! Usaste a lanterna para iluminar os teus medos e descobriste que não era um monstro. #portrait:narration #animation:Child_smiling #animation:Mother_smiling

Se voltares a sentir medo, já sabes: pede ajuda a um adulto ou acende a luz para ver o que são as sombras. #portrait:speech_right

O medo às vezes vem da nossa imaginação. Agora podes descansar tranquilo. #portrait:speech_right

Superar o medo é uma grande conquista! Agora sabes que, com coragem, podes enfrentar qualquer desafio que aparecer no teu caminho. #portrait:narration

-> END

=== minigame_puzzle_medo ===
Qual é a emoção que o João está a sentir? #portrait:narration #minigame:PuzzleMedo
-> continue1

=== minigame_lanterna_da_coragem ===
Minijogo Lanterna da Coragem #minigame:LanternaDaCoragem
-> continue2
