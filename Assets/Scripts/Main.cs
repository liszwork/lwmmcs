using UnityEngine;
using UnityEngine.Rendering;
using System.Collections.Generic;

[RequireComponent(typeof(Camera))]
public sealed class Main : MonoBehaviour
{
    public Font _Font;

    const int viewportW = 320;
    const int viewportH = 240;

    void Start()
    {
        // テキストメッシュを用意する
        var str = "Hello world!";
        var mesh = new Mesh();
        var generator = new TextGenerator(str.Length);
        var settings = new TextGenerationSettings()
        {
            textAnchor = TextAnchor.LowerLeft,
            font = _Font,
            fontSize = 24,
            color = Color.red,
            fontStyle = FontStyle.Normal,
            verticalOverflow = VerticalWrapMode.Overflow,
            horizontalOverflow = HorizontalWrapMode.Overflow,
            alignByGeometry = true,
            richText = false,
            lineSpacing = 1f,
            scaleFactor = 1f,
            resizeTextForBestFit = false
        };
        generator.Populate(str, settings);
        convertToMesh(ref mesh, ref generator);

        // コマンドバッファを作成する
        var commandBuffer = new CommandBuffer();
        commandBuffer.name = "TextCommand";

        // 描画先テクスチャを現在のレンダリングカメラに指定
        commandBuffer.SetRenderTarget(BuiltinRenderTextureType.CameraTarget);

        // 左下 320x240 の領域を描画ビューポートに指定
        commandBuffer.SetViewport(new Rect(0, 0, viewportW, viewportH));

        // 今回は2D描画なので、左下原点でドットバイドットになるような変換行列を指定
        commandBuffer.SetViewMatrix(Matrix4x4.TRS(new Vector3(-1f, -1f, 0), Quaternion.identity, new Vector3(2f / viewportW, 2f / viewportH, 1f)));

        // レンダーターゲットを白く塗りつぶす
        commandBuffer.ClearRenderTarget(true, true, Color.white);

        // 原点に文字列を描画
        commandBuffer.DrawMesh(mesh, Matrix4x4.identity, _Font.material);

        // メインカメラを取得し、背景を真っ黒にする
        var camera = GetComponent<Camera>();
        camera.clearFlags = CameraClearFlags.SolidColor;
        camera.backgroundColor = Color.black;

        // カメラにコマンドバッファを登録する。描画タイミングはTransparentの直前
        camera.AddCommandBuffer(CameraEvent.BeforeForwardAlpha, commandBuffer);
    }

    /// <summary>
    /// <see cref="UIVertex"/> を <see cref="Mesh"/> に変換する
    /// </summary>
    void convertToMesh(ref Mesh mesh, ref TextGenerator generator)
    {
        var vertexCount = generator.vertexCount;
        var v = new List<Vector3>(vertexCount);
        var u = new List<Vector2>(vertexCount);
        var t = new List<int>(vertexCount * 6);
        var c = new List<Color>(vertexCount);

        var uiverts = generator.verts;
        for ( var i = 0; i < vertexCount; i += 4 )
        {
            for ( var j = 0; j < 4; ++j )
            {
                var idx = i + j;
                v.Add(uiverts[idx].position);
                c.Add(uiverts[idx].color);
                u.Add(uiverts[idx].uv0);
            }
            t.Add(i);
            t.Add(i + 1);
            t.Add(i + 2);
            t.Add(i + 2);
            t.Add(i + 3);
            t.Add(i);
        }

        mesh.Clear();
        mesh.SetVertices(v);
        mesh.SetUVs(0, u);
        mesh.SetTriangles(t, 0);
        mesh.SetColors(c);
        mesh.RecalculateBounds();
    }
}
