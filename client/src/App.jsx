import { useEffect, useMemo, useState } from "react";

function useDebounce(v, d = 250) {
  const [x, setX] = useState(v);
  useEffect(() => {
    const t = setTimeout(() => setX(v), d);
    return () => clearTimeout(t);
  }, [v, d]);
  return x;
}

export default function App() {
  const API = import.meta.env.VITE_API_URL;
  const [q, setQ] = useState("");
  const dq = useDebounce(q, 250);
  const [games, setGames] = useState([]);
  const [loading, setLoading] = useState(false);

  const url = useMemo(() => {
    const u = new URL(`${API}/list`);
    if (dq.trim()) u.searchParams.set("search", dq.trim());
    return u.toString();
  }, [API, dq]);

  useEffect(() => {
    let alive = true;
    setLoading(true);

    fetch(url)
      .then((r) => r.json())
      .then((data) => alive && setGames(Array.isArray(data) ? data : []))
      .finally(() => alive && setLoading(false));

    return () => (alive = false);
  }, [url]);

  return (
    <div style={S.page}>
      <header style={S.header}>
        <div style={S.brand}>eneba</div>

        <input
          style={S.search}
          placeholder="Search games..."
          value={q}
          onChange={(e) => setQ(e.target.value)}
        />

        <div style={S.right}>Login</div>
      </header>

      <main style={{ padding: 18, maxWidth: 1100, margin: "0 auto", width: "100%" }}>
        <div style={S.titleRow}>
          <h2 style={S.title}>Games</h2>
          <div style={S.meta}>
            {loading ? "Loading..." : `${games.length} results`}
          </div>
        </div>

        <section style={S.grid}>
          {games.map((g) => (
            <article key={g.id} style={S.card}>
              <img alt={g.name} src={g.imageUrl} style={S.img} />

              <div style={S.body}>
                <div style={S.name}>{g.name}</div>
                <div style={S.platform}>{g.platform}</div>
                <div style={S.price}>
                  € {Number(g.priceEur).toFixed(2)}
                </div>
              </div>
            </article>
          ))}
        </section>
      </main>
    </div>
  );
}

const S = {
  page: {
    minHeight: "100vh",
    background: "#4b1fa3",
    color: "white",
    fontFamily: "system-ui",
  },
  header: {
    display: "flex",
    gap: 12,
    alignItems: "center",
    padding: "14px 18px",
    position: "sticky",
    top: 0,
    background: "rgba(40,10,90,0.85)",
  },
  brand: { fontWeight: 800, fontSize: 20 },
  search: {
    flex: 1,
    padding: "10px 12px",
    borderRadius: 10,
    border: "none",
  },
  right: { opacity: 0.9 },
  main: { padding: 18, maxWidth: 1100, margin: "0 auto" },
  titleRow: {
    display: "flex",
    justifyContent: "space-between",
    marginBottom: 12,
  },
  grid: {
    display: "grid",
    gridTemplateColumns: "repeat(auto-fit, minmax(210px, 1fr))",
    gap: 14,
  },
  card: {
    background: "rgba(255,255,255,0.08)",
    borderRadius: 14,
    overflow: "hidden",
  },
  img: { width: "100%", height: 260, objectFit: "cover" },
  body: { padding: 12 },
  name: { fontWeight: 700, marginBottom: 6 },
  platform: { opacity: 0.8, fontSize: 13, marginBottom: 10 },
  price: { fontWeight: 800 },
};