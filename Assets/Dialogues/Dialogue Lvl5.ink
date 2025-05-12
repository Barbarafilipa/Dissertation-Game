O professor pede para leres o texto que escreveste em voz alta para a turma. #portrait:narration
Quando olhas à tua volta, sentes o rosto a aquecer... 

-> minigame_puzzle_vergonha

=== continue1 ===
Parabéns, reconheceste a vergonha! A vergonha aparece quando sentimos que os outros estão a reparar em nós de forma negativa ou que nos vão julgar. #portrait:narration

Podes começar a ler quando estiveres pronto. #portrait:speech_right

-> main

=== main ===
Estão todos a olhar para mim... E agora? #portrait:thought 

+ [Hoje não quero ler!]

    Hoje não quero ler! #portrait:speech_left #animation:Friend_serious
    
    Eu sei que pode parecer mais fácil não fazer isso agora, mas o que custa é o primeiro passo. #portrait:speech_right 
    
    Depois perdes a vergonha, e vais ver que não é tão difícil quanto pensas.
    
    Vamos dar um passo de cada vez, sim?
    
    -> main
    
+ [Se eu me enganar vão todos gozar comigo, já sei que vai ser terrível.]

    Se eu me enganar vão todos gozar comigo, já sei que vai ser terrível. #portrait:speech_left
    
    Pensa na vergonha como uma bola de neve. #portrait:speech_right
    
    Quanto mais pensares no que pode correr mal, mais a bola cresce.
    
    É melhor parar, respirar e tentar com calma para desfazer a bola de neve. 
    
    -> main
    
+ [Mesmo que eu me engane, não faz mal, os meus colegas também se enganam.]

    Mesmo que eu me engane, não faz mal, os meus colegas também se enganam. #portrait:speech_left
    
    Isso mesmo! Imagina que estás a aprender a andar de bicicleta. #portrait:speech_right 
    
    No início é normal cair, mas é assim que se aprende a pedalar sem cair.
    
    Todos nós erramos, mas não precisas de te esconder!
    
    -> minigame_estrelas_da_confianca
    

=== continue2 ===
Parabéns! Cada estrela positiva ajudou a tua confiança a crescer. Agora és uma super estrela pronto para mais desafios! #portrait:narration 

-> novas_escolhas

=== novas_escolhas ===
Consegui! Senti-me bem a ler! #portrait:speech_left

Isso é alegria. E os teus colegas também gostaram do teu texto! #portrait:speech_right

+ [Vou tentar não sorrir para não acharem que sou convencido.]
    
    Vou tentar não sorrir para não acharem que sou convencido. #portrait:speech_left
    
    Quando mostramos aos outros como estamos felizes, estamos a partilhar algo bom. #portrait:speech_right
    
    Não precisas de esconder um sorriso. É natural e bonito de se ver!
    -> novas_escolhas

+ [Eu gostei e quero fazer mais vezes!]

    Eu gostei e quero fazer mais vezes! #portrait:speech_left
    
    Ainda bem! A alegria cresce quando repetimos algo bom. #portrait:speech_right

    -> continue4
    
=== continue4 ===

Lembras-te do que sentiste no início? Agora terminaste com um sorriso! A vergonha foi embora e a alegria ficou. #portrait:narration 

-> END

=== minigame_puzzle_vergonha ===
Qual é a emoção que o João está a sentir? #portrait:narration #minigame:PuzzleVergonha
-> continue1

=== minigame_estrelas_da_confianca ===
Minijogo Estrelas da Confiança #minigame:EstrelasdaConfianca
-> continue2
