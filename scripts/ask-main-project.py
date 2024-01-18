from templateframework.metadata import Metadata
import os

nome_solucao = None
caminho_solucao = None

def run(metadata: Metadata):
    diretorio_atual = os.getcwd()

    def encontrar_entry_point(diretorio):
        for pasta_raiz, _, arquivos in os.walk(diretorio):
            for arquivo in arquivos:
                if arquivo == "Program.cs":
                    caminho_program_cs = os.path.join(pasta_raiz, arquivo)
                    diretorio_pai = os.path.dirname(caminho_program_cs)
                    for arquivo in os.listdir(diretorio_pai):
                        if arquivo.endswith(".csproj"):
                            nome_projeto = os.path.splitext(arquivo)[0]
                            return nome_projeto
        return None

    nome_projeto = encontrar_entry_point(diretorio_atual)

    if nome_projeto:
        metadata.global_inputs["entrypoint"] = nome_projeto
        metadata.global_computed_inputs["entrypoint"] = nome_projeto

        metadata.global_inputs["repositorypath"] = f"/src/{nome_projeto}/{nome_projeto}.csproj"

        global nome_solucao, caminho_solucao
        caminho_solucao, nome_solucao = encontrar_nome_solucao(diretorio_atual)

        if nome_solucao:
            metadata.global_computed_inputs["solution_name"] = nome_solucao
        else:
            print("Nenhuma solução .sln encontrada.")
    else:
        print("Nenhum projeto de entrypoint encontrado.")

def encontrar_nome_solucao(diretorio):
    for pasta_raiz, _, arquivos in os.walk(diretorio):
        for arquivo in arquivos:
            if arquivo.endswith(".sln"):
                caminho_solucao = os.path.join(pasta_raiz, arquivo)
                nome_solucao = os.path.splitext(arquivo)[0]
                return caminho_solucao, nome_solucao
    return None, None