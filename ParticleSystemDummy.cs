using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.ParticleSystem;

// 这个类可以就是 unity 文档中说的记录 particle system 数据的类
// 至于怎么添加这个类到项目中
//      1、离线使用：需要考虑如何方便美术编辑，比如美术编辑打开关闭预制体需要支持自动修改和保存
//      2、运行时使用：需要考虑如何在加载时，把对象池初始模板里面的 particle system 替换为此组件，需要注意编排时对 particle system 的引用应该会失效
// 对于不同的项目需要结合项目的加载逻辑、制作流程、开发阶段做适配
public class ParticleSystemDummy : MonoBehaviour
{

    private PsData data;
    
    #region 特效数据
    // 反射生成，不同unity版本可能有区别
    public struct PsData
    {
        public float time;
        public uint randomSeed;
        public bool useAutoRandomSeed;
        public MainModule main;
        public EmissionModule emission;
        public ShapeModule shape;
        public VelocityOverLifetimeModule velocityOverLifetime;
        public LimitVelocityOverLifetimeModule limitVelocityOverLifetime;
        public InheritVelocityModule inheritVelocity;
        public LifetimeByEmitterSpeedModule lifetimeByEmitterSpeed;
        public ForceOverLifetimeModule forceOverLifetime;
        public ColorOverLifetimeModule colorOverLifetime;
        public ColorBySpeedModule colorBySpeed;
        public SizeOverLifetimeModule sizeOverLifetime;
        public SizeBySpeedModule sizeBySpeed;
        public RotationOverLifetimeModule rotationOverLifetime;
        public RotationBySpeedModule rotationBySpeed;
        public ExternalForcesModule externalForces;
        public NoiseModule noise;
        public CollisionModule collision;
        public TriggerModule trigger;
        public SubEmittersModule subEmitters;
        public TextureSheetAnimationModule textureSheetAnimation;
        public LightsModule lights;
        public TrailModule trails;
        public CustomDataModule customData;
        public string tag;
        public string name;
        public HideFlags hideFlags;

        public struct MainModule
        {
            public float duration;
            public bool loop;
            public bool prewarm;
            public MinMaxCurve startDelay;
            public float startDelayMultiplier;
            public MinMaxCurve startLifetime;
            public float startLifetimeMultiplier;
            public MinMaxCurve startSpeed;
            public float startSpeedMultiplier;
            public bool startSize3D;
            public MinMaxCurve startSize;
            public float startSizeMultiplier;
            public MinMaxCurve startSizeX;
            public float startSizeXMultiplier;
            public MinMaxCurve startSizeY;
            public float startSizeYMultiplier;
            public MinMaxCurve startSizeZ;
            public float startSizeZMultiplier;
            public bool startRotation3D;
            public MinMaxCurve startRotation;
            public float startRotationMultiplier;
            public MinMaxCurve startRotationX;
            public float startRotationXMultiplier;
            public MinMaxCurve startRotationY;
            public float startRotationYMultiplier;
            public MinMaxCurve startRotationZ;
            public float startRotationZMultiplier;
            public float flipRotation;
            public MinMaxGradient startColor;
            public MinMaxCurve gravityModifier;
            public float gravityModifierMultiplier;
            public ParticleSystemSimulationSpace simulationSpace;
            public Transform customSimulationSpace;
            public float simulationSpeed;
            public bool useUnscaledTime;
            public ParticleSystemScalingMode scalingMode;
            public bool playOnAwake;
            public int maxParticles;
            public ParticleSystemEmitterVelocityMode emitterVelocityMode;
            public ParticleSystemStopAction stopAction;
            public ParticleSystemRingBufferMode ringBufferMode;
            public Vector2 ringBufferLoopRange;
            public ParticleSystemCullingMode cullingMode;
        }

        public struct EmissionModule
        {
            public bool enabled;
            public MinMaxCurve rateOverTime;
            public float rateOverTimeMultiplier;
            public MinMaxCurve rateOverDistance;
            public float rateOverDistanceMultiplier;
            public int burstCount;
        }

        public struct ShapeModule
        {
            public bool enabled;
            public ParticleSystemShapeType shapeType;
            public float randomDirectionAmount;
            public float sphericalDirectionAmount;
            public float randomPositionAmount;
            public bool alignToDirection;
            public float radius;
            public ParticleSystemShapeMultiModeValue radiusMode;
            public float radiusSpread;
            public MinMaxCurve radiusSpeed;
            public float radiusSpeedMultiplier;
            public float radiusThickness;
            public float angle;
            public float length;
            public Vector3 boxThickness;
            public ParticleSystemMeshShapeType meshShapeType;
            public Mesh mesh;
            public MeshRenderer meshRenderer;
            public SkinnedMeshRenderer skinnedMeshRenderer;
            public Sprite sprite;
            public SpriteRenderer spriteRenderer;
            public bool useMeshMaterialIndex;
            public int meshMaterialIndex;
            public bool useMeshColors;
            public float normalOffset;
            public ParticleSystemShapeMultiModeValue meshSpawnMode;
            public float meshSpawnSpread;
            public MinMaxCurve meshSpawnSpeed;
            public float meshSpawnSpeedMultiplier;
            public float arc;
            public ParticleSystemShapeMultiModeValue arcMode;
            public float arcSpread;
            public MinMaxCurve arcSpeed;
            public float arcSpeedMultiplier;
            public float donutRadius;
            public Vector3 position;
            public Vector3 rotation;
            public Vector3 scale;
            public Texture2D texture;
            public ParticleSystemShapeTextureChannel textureClipChannel;
            public float textureClipThreshold;
            public bool textureColorAffectsParticles;
            public bool textureAlphaAffectsParticles;
            public bool textureBilinearFiltering;
            public int textureUVChannel;
        }

        public struct VelocityOverLifetimeModule
        {
            public bool enabled;
            public MinMaxCurve x;
            public MinMaxCurve y;
            public MinMaxCurve z;
            public float xMultiplier;
            public float yMultiplier;
            public float zMultiplier;
            public MinMaxCurve orbitalX;
            public MinMaxCurve orbitalY;
            public MinMaxCurve orbitalZ;
            public float orbitalXMultiplier;
            public float orbitalYMultiplier;
            public float orbitalZMultiplier;
            public MinMaxCurve orbitalOffsetX;
            public MinMaxCurve orbitalOffsetY;
            public MinMaxCurve orbitalOffsetZ;
            public float orbitalOffsetXMultiplier;
            public float orbitalOffsetYMultiplier;
            public float orbitalOffsetZMultiplier;
            public MinMaxCurve radial;
            public float radialMultiplier;
            public MinMaxCurve speedModifier;
            public float speedModifierMultiplier;
            public ParticleSystemSimulationSpace space;
        }

        public struct LimitVelocityOverLifetimeModule
        {
            public bool enabled;
            public MinMaxCurve limitX;
            public float limitXMultiplier;
            public MinMaxCurve limitY;
            public float limitYMultiplier;
            public MinMaxCurve limitZ;
            public float limitZMultiplier;
            public MinMaxCurve limit;
            public float limitMultiplier;
            public float dampen;
            public bool separateAxes;
            public ParticleSystemSimulationSpace space;
            public MinMaxCurve drag;
            public float dragMultiplier;
            public bool multiplyDragByParticleSize;
            public bool multiplyDragByParticleVelocity;
        }

        public struct InheritVelocityModule
        {
            public bool enabled;
            public ParticleSystemInheritVelocityMode mode;
            public MinMaxCurve curve;
            public float curveMultiplier;
        }

        public struct LifetimeByEmitterSpeedModule
        {
            public bool enabled;
            public MinMaxCurve curve;
            public float curveMultiplier;
            public Vector2 range;
        }

        public struct ForceOverLifetimeModule
        {
            public bool enabled;
            public MinMaxCurve x;
            public MinMaxCurve y;
            public MinMaxCurve z;
            public float xMultiplier;
            public float yMultiplier;
            public float zMultiplier;
            public ParticleSystemSimulationSpace space;
            public bool randomized;
        }

        public struct ColorOverLifetimeModule
        {
            public bool enabled;
            public MinMaxGradient color;
        }

        public struct ColorBySpeedModule
        {
            public bool enabled;
            public MinMaxGradient color;
            public Vector2 range;
        }

        public struct SizeOverLifetimeModule
        {
            public bool enabled;
            public MinMaxCurve size;
            public float sizeMultiplier;
            public MinMaxCurve x;
            public float xMultiplier;
            public MinMaxCurve y;
            public float yMultiplier;
            public MinMaxCurve z;
            public float zMultiplier;
            public bool separateAxes;
        }

        public struct SizeBySpeedModule
        {
            public bool enabled;
            public MinMaxCurve size;
            public float sizeMultiplier;
            public MinMaxCurve x;
            public float xMultiplier;
            public MinMaxCurve y;
            public float yMultiplier;
            public MinMaxCurve z;
            public float zMultiplier;
            public bool separateAxes;
            public Vector2 range;
        }

        public struct RotationOverLifetimeModule
        {
            public bool enabled;
            public MinMaxCurve x;
            public float xMultiplier;
            public MinMaxCurve y;
            public float yMultiplier;
            public MinMaxCurve z;
            public float zMultiplier;
            public bool separateAxes;
        }

        public struct RotationBySpeedModule
        {
            public bool enabled;
            public MinMaxCurve x;
            public float xMultiplier;
            public MinMaxCurve y;
            public float yMultiplier;
            public MinMaxCurve z;
            public float zMultiplier;
            public bool separateAxes;
            public Vector2 range;
        }

        public struct ExternalForcesModule
        {
            public bool enabled;
            public float multiplier;
            public MinMaxCurve multiplierCurve;
            public ParticleSystemGameObjectFilter influenceFilter;
            public LayerMask influenceMask;
        }

        public struct NoiseModule
        {
            public bool enabled;
            public bool separateAxes;
            public MinMaxCurve strength;
            public float strengthMultiplier;
            public MinMaxCurve strengthX;
            public float strengthXMultiplier;
            public MinMaxCurve strengthY;
            public float strengthYMultiplier;
            public MinMaxCurve strengthZ;
            public float strengthZMultiplier;
            public float frequency;
            public bool damping;
            public int octaveCount;
            public float octaveMultiplier;
            public float octaveScale;
            public ParticleSystemNoiseQuality quality;
            public MinMaxCurve scrollSpeed;
            public float scrollSpeedMultiplier;
            public bool remapEnabled;
            public MinMaxCurve remap;
            public float remapMultiplier;
            public MinMaxCurve remapX;
            public float remapXMultiplier;
            public MinMaxCurve remapY;
            public float remapYMultiplier;
            public MinMaxCurve remapZ;
            public float remapZMultiplier;
            public MinMaxCurve positionAmount;
            public MinMaxCurve rotationAmount;
            public MinMaxCurve sizeAmount;
        }

        public struct CollisionModule
        {
            public bool enabled;
            public ParticleSystemCollisionType type;
            public ParticleSystemCollisionMode mode;
            public MinMaxCurve dampen;
            public float dampenMultiplier;
            public MinMaxCurve bounce;
            public float bounceMultiplier;
            public MinMaxCurve lifetimeLoss;
            public float lifetimeLossMultiplier;
            public float minKillSpeed;
            public float maxKillSpeed;
            public LayerMask collidesWith;
            public bool enableDynamicColliders;
            public int maxCollisionShapes;
            public ParticleSystemCollisionQuality quality;
            public float voxelSize;
            public float radiusScale;
            public bool sendCollisionMessages;
            public float colliderForce;
            public bool multiplyColliderForceByCollisionAngle;
            public bool multiplyColliderForceByParticleSpeed;
            public bool multiplyColliderForceByParticleSize;
        }

        public struct TriggerModule
        {
            public bool enabled;
            public ParticleSystemOverlapAction inside;
            public ParticleSystemOverlapAction outside;
            public ParticleSystemOverlapAction enter;
            public ParticleSystemOverlapAction exit;
            public ParticleSystemColliderQueryMode colliderQueryMode;
            public float radiusScale;
        }

        public struct SubEmittersModule
        {
            public bool enabled;
        }

        public struct TextureSheetAnimationModule
        {
            public bool enabled;
            public ParticleSystemAnimationMode mode;
            public ParticleSystemAnimationTimeMode timeMode;
            public float fps;
            public int numTilesX;
            public int numTilesY;
            public ParticleSystemAnimationType animation;
            public ParticleSystemAnimationRowMode rowMode;
            public MinMaxCurve frameOverTime;
            public float frameOverTimeMultiplier;
            public MinMaxCurve startFrame;
            public float startFrameMultiplier;
            public int cycleCount;
            public int rowIndex;
            public UVChannelFlags uvChannelMask;
            public Vector2 speedRange;
        }

        public struct LightsModule
        {
            public bool enabled;
            public float ratio;
            public bool useRandomDistribution;
            public Light light;
            public bool useParticleColor;
            public bool sizeAffectsRange;
            public bool alphaAffectsIntensity;
            public MinMaxCurve range;
            public float rangeMultiplier;
            public MinMaxCurve intensity;
            public float intensityMultiplier;
            public int maxLights;
        }

        public struct TrailModule
        {
            public bool enabled;
            public ParticleSystemTrailMode mode;
            public float ratio;
            public MinMaxCurve lifetime;
            public float lifetimeMultiplier;
            public float minVertexDistance;
            public ParticleSystemTrailTextureMode textureMode;
            public bool worldSpace;
            public bool dieWithParticles;
            public bool sizeAffectsWidth;
            public bool sizeAffectsLifetime;
            public bool inheritParticleColor;
            public MinMaxGradient colorOverLifetime;
            public MinMaxCurve widthOverTrail;
            public float widthOverTrailMultiplier;
            public MinMaxGradient colorOverTrail;
            public bool generateLightingData;
            public int ribbonCount;
            public float shadowBias;
            public bool splitSubEmitterRibbons;
            public bool attachRibbonsToTransform;
        }

        public struct CustomDataModule
        {
            public bool enabled;
        }
    }

    // 反射生成，不同unity版本可能有区别
    public void RecordParticleSystemData(ParticleSystem ps)
    {
        data.time = ps.time;
        data.randomSeed = ps.randomSeed;
        data.useAutoRandomSeed = ps.useAutoRandomSeed;
        var main = ps.main;
        data.main.duration = main.duration;
        data.main.loop = main.loop;
        data.main.prewarm = main.prewarm;
        data.main.startDelay = main.startDelay;
        data.main.startDelayMultiplier = main.startDelayMultiplier;
        data.main.startLifetime = main.startLifetime;
        data.main.startLifetimeMultiplier = main.startLifetimeMultiplier;
        data.main.startSpeed = main.startSpeed;
        data.main.startSpeedMultiplier = main.startSpeedMultiplier;
        data.main.startSize3D = main.startSize3D;
        data.main.startSize = main.startSize;
        data.main.startSizeMultiplier = main.startSizeMultiplier;
        data.main.startSizeX = main.startSizeX;
        data.main.startSizeXMultiplier = main.startSizeXMultiplier;
        data.main.startSizeY = main.startSizeY;
        data.main.startSizeYMultiplier = main.startSizeYMultiplier;
        data.main.startSizeZ = main.startSizeZ;
        data.main.startSizeZMultiplier = main.startSizeZMultiplier;
        data.main.startRotation3D = main.startRotation3D;
        data.main.startRotation = main.startRotation;
        data.main.startRotationMultiplier = main.startRotationMultiplier;
        data.main.startRotationX = main.startRotationX;
        data.main.startRotationXMultiplier = main.startRotationXMultiplier;
        data.main.startRotationY = main.startRotationY;
        data.main.startRotationYMultiplier = main.startRotationYMultiplier;
        data.main.startRotationZ = main.startRotationZ;
        data.main.startRotationZMultiplier = main.startRotationZMultiplier;
        data.main.flipRotation = main.flipRotation;
        data.main.startColor = main.startColor;
        data.main.gravityModifier = main.gravityModifier;
        data.main.gravityModifierMultiplier = main.gravityModifierMultiplier;
        data.main.simulationSpace = main.simulationSpace;
        data.main.customSimulationSpace = main.customSimulationSpace;
        data.main.simulationSpeed = main.simulationSpeed;
        data.main.useUnscaledTime = main.useUnscaledTime;
        data.main.scalingMode = main.scalingMode;
        data.main.playOnAwake = main.playOnAwake;
        data.main.maxParticles = main.maxParticles;
        data.main.emitterVelocityMode = main.emitterVelocityMode;
        data.main.stopAction = main.stopAction;
        data.main.ringBufferMode = main.ringBufferMode;
        data.main.ringBufferLoopRange = main.ringBufferLoopRange;
        data.main.cullingMode = main.cullingMode;
        var emission = ps.emission;
        data.emission.enabled = emission.enabled;
        data.emission.rateOverTime = emission.rateOverTime;
        data.emission.rateOverTimeMultiplier = emission.rateOverTimeMultiplier;
        data.emission.rateOverDistance = emission.rateOverDistance;
        data.emission.rateOverDistanceMultiplier = emission.rateOverDistanceMultiplier;
        data.emission.burstCount = emission.burstCount;
        var shape = ps.shape;
        data.shape.enabled = shape.enabled;
        data.shape.shapeType = shape.shapeType;
        data.shape.randomDirectionAmount = shape.randomDirectionAmount;
        data.shape.sphericalDirectionAmount = shape.sphericalDirectionAmount;
        data.shape.randomPositionAmount = shape.randomPositionAmount;
        data.shape.alignToDirection = shape.alignToDirection;
        data.shape.radius = shape.radius;
        data.shape.radiusMode = shape.radiusMode;
        data.shape.radiusSpread = shape.radiusSpread;
        data.shape.radiusSpeed = shape.radiusSpeed;
        data.shape.radiusSpeedMultiplier = shape.radiusSpeedMultiplier;
        data.shape.radiusThickness = shape.radiusThickness;
        data.shape.angle = shape.angle;
        data.shape.length = shape.length;
        data.shape.boxThickness = shape.boxThickness;
        data.shape.meshShapeType = shape.meshShapeType;
        data.shape.mesh = shape.mesh;
        data.shape.meshRenderer = shape.meshRenderer;
        data.shape.skinnedMeshRenderer = shape.skinnedMeshRenderer;
        data.shape.sprite = shape.sprite;
        data.shape.spriteRenderer = shape.spriteRenderer;
        data.shape.useMeshMaterialIndex = shape.useMeshMaterialIndex;
        data.shape.meshMaterialIndex = shape.meshMaterialIndex;
        data.shape.useMeshColors = shape.useMeshColors;
        data.shape.normalOffset = shape.normalOffset;
        data.shape.meshSpawnMode = shape.meshSpawnMode;
        data.shape.meshSpawnSpread = shape.meshSpawnSpread;
        data.shape.meshSpawnSpeed = shape.meshSpawnSpeed;
        data.shape.meshSpawnSpeedMultiplier = shape.meshSpawnSpeedMultiplier;
        data.shape.arc = shape.arc;
        data.shape.arcMode = shape.arcMode;
        data.shape.arcSpread = shape.arcSpread;
        data.shape.arcSpeed = shape.arcSpeed;
        data.shape.arcSpeedMultiplier = shape.arcSpeedMultiplier;
        data.shape.donutRadius = shape.donutRadius;
        data.shape.position = shape.position;
        data.shape.rotation = shape.rotation;
        data.shape.scale = shape.scale;
        data.shape.texture = shape.texture;
        data.shape.textureClipChannel = shape.textureClipChannel;
        data.shape.textureClipThreshold = shape.textureClipThreshold;
        data.shape.textureColorAffectsParticles = shape.textureColorAffectsParticles;
        data.shape.textureAlphaAffectsParticles = shape.textureAlphaAffectsParticles;
        data.shape.textureBilinearFiltering = shape.textureBilinearFiltering;
        data.shape.textureUVChannel = shape.textureUVChannel;
        var velocityOverLifetime = ps.velocityOverLifetime;
        data.velocityOverLifetime.enabled = velocityOverLifetime.enabled;
        data.velocityOverLifetime.x = velocityOverLifetime.x;
        data.velocityOverLifetime.y = velocityOverLifetime.y;
        data.velocityOverLifetime.z = velocityOverLifetime.z;
        data.velocityOverLifetime.xMultiplier = velocityOverLifetime.xMultiplier;
        data.velocityOverLifetime.yMultiplier = velocityOverLifetime.yMultiplier;
        data.velocityOverLifetime.zMultiplier = velocityOverLifetime.zMultiplier;
        data.velocityOverLifetime.orbitalX = velocityOverLifetime.orbitalX;
        data.velocityOverLifetime.orbitalY = velocityOverLifetime.orbitalY;
        data.velocityOverLifetime.orbitalZ = velocityOverLifetime.orbitalZ;
        data.velocityOverLifetime.orbitalXMultiplier = velocityOverLifetime.orbitalXMultiplier;
        data.velocityOverLifetime.orbitalYMultiplier = velocityOverLifetime.orbitalYMultiplier;
        data.velocityOverLifetime.orbitalZMultiplier = velocityOverLifetime.orbitalZMultiplier;
        data.velocityOverLifetime.orbitalOffsetX = velocityOverLifetime.orbitalOffsetX;
        data.velocityOverLifetime.orbitalOffsetY = velocityOverLifetime.orbitalOffsetY;
        data.velocityOverLifetime.orbitalOffsetZ = velocityOverLifetime.orbitalOffsetZ;
        data.velocityOverLifetime.orbitalOffsetXMultiplier = velocityOverLifetime.orbitalOffsetXMultiplier;
        data.velocityOverLifetime.orbitalOffsetYMultiplier = velocityOverLifetime.orbitalOffsetYMultiplier;
        data.velocityOverLifetime.orbitalOffsetZMultiplier = velocityOverLifetime.orbitalOffsetZMultiplier;
        data.velocityOverLifetime.radial = velocityOverLifetime.radial;
        data.velocityOverLifetime.radialMultiplier = velocityOverLifetime.radialMultiplier;
        data.velocityOverLifetime.speedModifier = velocityOverLifetime.speedModifier;
        data.velocityOverLifetime.speedModifierMultiplier = velocityOverLifetime.speedModifierMultiplier;
        data.velocityOverLifetime.space = velocityOverLifetime.space;
        var limitVelocityOverLifetime = ps.limitVelocityOverLifetime;
        data.limitVelocityOverLifetime.enabled = limitVelocityOverLifetime.enabled;
        data.limitVelocityOverLifetime.limitX = limitVelocityOverLifetime.limitX;
        data.limitVelocityOverLifetime.limitXMultiplier = limitVelocityOverLifetime.limitXMultiplier;
        data.limitVelocityOverLifetime.limitY = limitVelocityOverLifetime.limitY;
        data.limitVelocityOverLifetime.limitYMultiplier = limitVelocityOverLifetime.limitYMultiplier;
        data.limitVelocityOverLifetime.limitZ = limitVelocityOverLifetime.limitZ;
        data.limitVelocityOverLifetime.limitZMultiplier = limitVelocityOverLifetime.limitZMultiplier;
        data.limitVelocityOverLifetime.limit = limitVelocityOverLifetime.limit;
        data.limitVelocityOverLifetime.limitMultiplier = limitVelocityOverLifetime.limitMultiplier;
        data.limitVelocityOverLifetime.dampen = limitVelocityOverLifetime.dampen;
        data.limitVelocityOverLifetime.separateAxes = limitVelocityOverLifetime.separateAxes;
        data.limitVelocityOverLifetime.space = limitVelocityOverLifetime.space;
        data.limitVelocityOverLifetime.drag = limitVelocityOverLifetime.drag;
        data.limitVelocityOverLifetime.dragMultiplier = limitVelocityOverLifetime.dragMultiplier;
        data.limitVelocityOverLifetime.multiplyDragByParticleSize =
            limitVelocityOverLifetime.multiplyDragByParticleSize;
        data.limitVelocityOverLifetime.multiplyDragByParticleVelocity =
            limitVelocityOverLifetime.multiplyDragByParticleVelocity;
        var inheritVelocity = ps.inheritVelocity;
        data.inheritVelocity.enabled = inheritVelocity.enabled;
        data.inheritVelocity.mode = inheritVelocity.mode;
        data.inheritVelocity.curve = inheritVelocity.curve;
        data.inheritVelocity.curveMultiplier = inheritVelocity.curveMultiplier;
        var lifetimeByEmitterSpeed = ps.lifetimeByEmitterSpeed;
        data.lifetimeByEmitterSpeed.enabled = lifetimeByEmitterSpeed.enabled;
        data.lifetimeByEmitterSpeed.curve = lifetimeByEmitterSpeed.curve;
        data.lifetimeByEmitterSpeed.curveMultiplier = lifetimeByEmitterSpeed.curveMultiplier;
        data.lifetimeByEmitterSpeed.range = lifetimeByEmitterSpeed.range;
        var forceOverLifetime = ps.forceOverLifetime;
        data.forceOverLifetime.enabled = forceOverLifetime.enabled;
        data.forceOverLifetime.x = forceOverLifetime.x;
        data.forceOverLifetime.y = forceOverLifetime.y;
        data.forceOverLifetime.z = forceOverLifetime.z;
        data.forceOverLifetime.xMultiplier = forceOverLifetime.xMultiplier;
        data.forceOverLifetime.yMultiplier = forceOverLifetime.yMultiplier;
        data.forceOverLifetime.zMultiplier = forceOverLifetime.zMultiplier;
        data.forceOverLifetime.space = forceOverLifetime.space;
        data.forceOverLifetime.randomized = forceOverLifetime.randomized;
        var colorOverLifetime = ps.colorOverLifetime;
        data.colorOverLifetime.enabled = colorOverLifetime.enabled;
        data.colorOverLifetime.color = colorOverLifetime.color;
        var colorBySpeed = ps.colorBySpeed;
        data.colorBySpeed.enabled = colorBySpeed.enabled;
        data.colorBySpeed.color = colorBySpeed.color;
        data.colorBySpeed.range = colorBySpeed.range;
        var sizeOverLifetime = ps.sizeOverLifetime;
        data.sizeOverLifetime.enabled = sizeOverLifetime.enabled;
        data.sizeOverLifetime.size = sizeOverLifetime.size;
        data.sizeOverLifetime.sizeMultiplier = sizeOverLifetime.sizeMultiplier;
        data.sizeOverLifetime.x = sizeOverLifetime.x;
        data.sizeOverLifetime.xMultiplier = sizeOverLifetime.xMultiplier;
        data.sizeOverLifetime.y = sizeOverLifetime.y;
        data.sizeOverLifetime.yMultiplier = sizeOverLifetime.yMultiplier;
        data.sizeOverLifetime.z = sizeOverLifetime.z;
        data.sizeOverLifetime.zMultiplier = sizeOverLifetime.zMultiplier;
        data.sizeOverLifetime.separateAxes = sizeOverLifetime.separateAxes;
        var sizeBySpeed = ps.sizeBySpeed;
        data.sizeBySpeed.enabled = sizeBySpeed.enabled;
        data.sizeBySpeed.size = sizeBySpeed.size;
        data.sizeBySpeed.sizeMultiplier = sizeBySpeed.sizeMultiplier;
        data.sizeBySpeed.x = sizeBySpeed.x;
        data.sizeBySpeed.xMultiplier = sizeBySpeed.xMultiplier;
        data.sizeBySpeed.y = sizeBySpeed.y;
        data.sizeBySpeed.yMultiplier = sizeBySpeed.yMultiplier;
        data.sizeBySpeed.z = sizeBySpeed.z;
        data.sizeBySpeed.zMultiplier = sizeBySpeed.zMultiplier;
        data.sizeBySpeed.separateAxes = sizeBySpeed.separateAxes;
        data.sizeBySpeed.range = sizeBySpeed.range;
        var rotationOverLifetime = ps.rotationOverLifetime;
        data.rotationOverLifetime.enabled = rotationOverLifetime.enabled;
        data.rotationOverLifetime.x = rotationOverLifetime.x;
        data.rotationOverLifetime.xMultiplier = rotationOverLifetime.xMultiplier;
        data.rotationOverLifetime.y = rotationOverLifetime.y;
        data.rotationOverLifetime.yMultiplier = rotationOverLifetime.yMultiplier;
        data.rotationOverLifetime.z = rotationOverLifetime.z;
        data.rotationOverLifetime.zMultiplier = rotationOverLifetime.zMultiplier;
        data.rotationOverLifetime.separateAxes = rotationOverLifetime.separateAxes;
        var rotationBySpeed = ps.rotationBySpeed;
        data.rotationBySpeed.enabled = rotationBySpeed.enabled;
        data.rotationBySpeed.x = rotationBySpeed.x;
        data.rotationBySpeed.xMultiplier = rotationBySpeed.xMultiplier;
        data.rotationBySpeed.y = rotationBySpeed.y;
        data.rotationBySpeed.yMultiplier = rotationBySpeed.yMultiplier;
        data.rotationBySpeed.z = rotationBySpeed.z;
        data.rotationBySpeed.zMultiplier = rotationBySpeed.zMultiplier;
        data.rotationBySpeed.separateAxes = rotationBySpeed.separateAxes;
        data.rotationBySpeed.range = rotationBySpeed.range;
        var externalForces = ps.externalForces;
        data.externalForces.enabled = externalForces.enabled;
        data.externalForces.multiplier = externalForces.multiplier;
        data.externalForces.multiplierCurve = externalForces.multiplierCurve;
        data.externalForces.influenceFilter = externalForces.influenceFilter;
        data.externalForces.influenceMask = externalForces.influenceMask;
        var noise = ps.noise;
        data.noise.enabled = noise.enabled;
        data.noise.separateAxes = noise.separateAxes;
        data.noise.strength = noise.strength;
        data.noise.strengthMultiplier = noise.strengthMultiplier;
        data.noise.strengthX = noise.strengthX;
        data.noise.strengthXMultiplier = noise.strengthXMultiplier;
        data.noise.strengthY = noise.strengthY;
        data.noise.strengthYMultiplier = noise.strengthYMultiplier;
        data.noise.strengthZ = noise.strengthZ;
        data.noise.strengthZMultiplier = noise.strengthZMultiplier;
        data.noise.frequency = noise.frequency;
        data.noise.damping = noise.damping;
        data.noise.octaveCount = noise.octaveCount;
        data.noise.octaveMultiplier = noise.octaveMultiplier;
        data.noise.octaveScale = noise.octaveScale;
        data.noise.quality = noise.quality;
        data.noise.scrollSpeed = noise.scrollSpeed;
        data.noise.scrollSpeedMultiplier = noise.scrollSpeedMultiplier;
        data.noise.remapEnabled = noise.remapEnabled;
        data.noise.remap = noise.remap;
        data.noise.remapMultiplier = noise.remapMultiplier;
        data.noise.remapX = noise.remapX;
        data.noise.remapXMultiplier = noise.remapXMultiplier;
        data.noise.remapY = noise.remapY;
        data.noise.remapYMultiplier = noise.remapYMultiplier;
        data.noise.remapZ = noise.remapZ;
        data.noise.remapZMultiplier = noise.remapZMultiplier;
        data.noise.positionAmount = noise.positionAmount;
        data.noise.rotationAmount = noise.rotationAmount;
        data.noise.sizeAmount = noise.sizeAmount;
        var collision = ps.collision;
        data.collision.enabled = collision.enabled;
        data.collision.type = collision.type;
        data.collision.mode = collision.mode;
        data.collision.dampen = collision.dampen;
        data.collision.dampenMultiplier = collision.dampenMultiplier;
        data.collision.bounce = collision.bounce;
        data.collision.bounceMultiplier = collision.bounceMultiplier;
        data.collision.lifetimeLoss = collision.lifetimeLoss;
        data.collision.lifetimeLossMultiplier = collision.lifetimeLossMultiplier;
        data.collision.minKillSpeed = collision.minKillSpeed;
        data.collision.maxKillSpeed = collision.maxKillSpeed;
        data.collision.collidesWith = collision.collidesWith;
        data.collision.enableDynamicColliders = collision.enableDynamicColliders;
        data.collision.maxCollisionShapes = collision.maxCollisionShapes;
        data.collision.quality = collision.quality;
        data.collision.voxelSize = collision.voxelSize;
        data.collision.radiusScale = collision.radiusScale;
        data.collision.sendCollisionMessages = collision.sendCollisionMessages;
        data.collision.colliderForce = collision.colliderForce;
        data.collision.multiplyColliderForceByCollisionAngle = collision.multiplyColliderForceByCollisionAngle;
        data.collision.multiplyColliderForceByParticleSpeed = collision.multiplyColliderForceByParticleSpeed;
        data.collision.multiplyColliderForceByParticleSize = collision.multiplyColliderForceByParticleSize;
        var trigger = ps.trigger;
        data.trigger.enabled = trigger.enabled;
        data.trigger.inside = trigger.inside;
        data.trigger.outside = trigger.outside;
        data.trigger.enter = trigger.enter;
        data.trigger.exit = trigger.exit;
        data.trigger.colliderQueryMode = trigger.colliderQueryMode;
        data.trigger.radiusScale = trigger.radiusScale;
        data.subEmitters.enabled = ps.subEmitters.enabled;
        var textureSheetAnimation = ps.textureSheetAnimation;
        data.textureSheetAnimation.enabled = textureSheetAnimation.enabled;
        data.textureSheetAnimation.mode = textureSheetAnimation.mode;
        data.textureSheetAnimation.timeMode = textureSheetAnimation.timeMode;
        data.textureSheetAnimation.fps = textureSheetAnimation.fps;
        data.textureSheetAnimation.numTilesX = textureSheetAnimation.numTilesX;
        data.textureSheetAnimation.numTilesY = textureSheetAnimation.numTilesY;
        data.textureSheetAnimation.animation = textureSheetAnimation.animation;
        data.textureSheetAnimation.rowMode = textureSheetAnimation.rowMode;
        data.textureSheetAnimation.frameOverTime = textureSheetAnimation.frameOverTime;
        data.textureSheetAnimation.frameOverTimeMultiplier = textureSheetAnimation.frameOverTimeMultiplier;
        data.textureSheetAnimation.startFrame = textureSheetAnimation.startFrame;
        data.textureSheetAnimation.startFrameMultiplier = textureSheetAnimation.startFrameMultiplier;
        data.textureSheetAnimation.cycleCount = textureSheetAnimation.cycleCount;
        data.textureSheetAnimation.rowIndex = textureSheetAnimation.rowIndex;
        data.textureSheetAnimation.uvChannelMask = textureSheetAnimation.uvChannelMask;
        data.textureSheetAnimation.speedRange = textureSheetAnimation.speedRange;
        var lights = ps.lights;
        data.lights.enabled = lights.enabled;
        data.lights.ratio = lights.ratio;
        data.lights.useRandomDistribution = lights.useRandomDistribution;
        data.lights.light = lights.light;
        data.lights.useParticleColor = lights.useParticleColor;
        data.lights.sizeAffectsRange = lights.sizeAffectsRange;
        data.lights.alphaAffectsIntensity = lights.alphaAffectsIntensity;
        data.lights.range = lights.range;
        data.lights.rangeMultiplier = lights.rangeMultiplier;
        data.lights.intensity = lights.intensity;
        data.lights.intensityMultiplier = lights.intensityMultiplier;
        data.lights.maxLights = lights.maxLights;
        var trails = ps.trails;
        data.trails.enabled = trails.enabled;
        data.trails.mode = trails.mode;
        data.trails.ratio = trails.ratio;
        data.trails.lifetime = trails.lifetime;
        data.trails.lifetimeMultiplier = trails.lifetimeMultiplier;
        data.trails.minVertexDistance = trails.minVertexDistance;
        data.trails.textureMode = trails.textureMode;
        data.trails.worldSpace = trails.worldSpace;
        data.trails.dieWithParticles = trails.dieWithParticles;
        data.trails.sizeAffectsWidth = trails.sizeAffectsWidth;
        data.trails.sizeAffectsLifetime = trails.sizeAffectsLifetime;
        data.trails.inheritParticleColor = trails.inheritParticleColor;
        data.trails.colorOverLifetime = trails.colorOverLifetime;
        data.trails.widthOverTrail = trails.widthOverTrail;
        data.trails.widthOverTrailMultiplier = trails.widthOverTrailMultiplier;
        data.trails.colorOverTrail = trails.colorOverTrail;
        data.trails.generateLightingData = trails.generateLightingData;
        data.trails.ribbonCount = trails.ribbonCount;
        data.trails.shadowBias = trails.shadowBias;
        data.trails.splitSubEmitterRibbons = trails.splitSubEmitterRibbons;
        data.trails.attachRibbonsToTransform = trails.attachRibbonsToTransform;
        data.customData.enabled = ps.customData.enabled;
        data.tag = ps.tag;
        data.name = ps.name;
        data.hideFlags = ps.hideFlags;
    }
    
    // 反射生成，不同unity版本可能有区别
    private void ApplyParticleSystemData(ParticleSystem ps)
    {
        ps.time = data.time;
        ps.randomSeed = data.randomSeed;
        ps.useAutoRandomSeed = data.useAutoRandomSeed;
        var main = ps.main;
        main.duration = data.main.duration;
        main.loop = data.main.loop;
        main.prewarm = data.main.prewarm;
        main.startDelay = data.main.startDelay;
        main.startDelayMultiplier = data.main.startDelayMultiplier;
        main.startLifetime = data.main.startLifetime;
        main.startLifetimeMultiplier = data.main.startLifetimeMultiplier;
        main.startSpeed = data.main.startSpeed;
        main.startSpeedMultiplier = data.main.startSpeedMultiplier;
        main.startSize3D = data.main.startSize3D;
        main.startSize = data.main.startSize;
        main.startSizeMultiplier = data.main.startSizeMultiplier;
        main.startSizeX = data.main.startSizeX;
        main.startSizeXMultiplier = data.main.startSizeXMultiplier;
        main.startSizeY = data.main.startSizeY;
        main.startSizeYMultiplier = data.main.startSizeYMultiplier;
        main.startSizeZ = data.main.startSizeZ;
        main.startSizeZMultiplier = data.main.startSizeZMultiplier;
        main.startRotation3D = data.main.startRotation3D;
        main.startRotation = data.main.startRotation;
        main.startRotationMultiplier = data.main.startRotationMultiplier;
        main.startRotationX = data.main.startRotationX;
        main.startRotationXMultiplier = data.main.startRotationXMultiplier;
        main.startRotationY = data.main.startRotationY;
        main.startRotationYMultiplier = data.main.startRotationYMultiplier;
        main.startRotationZ = data.main.startRotationZ;
        main.startRotationZMultiplier = data.main.startRotationZMultiplier;
        main.flipRotation = data.main.flipRotation;
        main.startColor = data.main.startColor;
        main.gravityModifier = data.main.gravityModifier;
        main.gravityModifierMultiplier = data.main.gravityModifierMultiplier;
        main.simulationSpace = data.main.simulationSpace;
        main.customSimulationSpace = data.main.customSimulationSpace;
        main.simulationSpeed = data.main.simulationSpeed;
        main.useUnscaledTime = data.main.useUnscaledTime;
        main.scalingMode = data.main.scalingMode;
        main.playOnAwake = data.main.playOnAwake;
        main.maxParticles = data.main.maxParticles;
        main.emitterVelocityMode = data.main.emitterVelocityMode;
        main.stopAction = data.main.stopAction;
        main.ringBufferMode = data.main.ringBufferMode;
        main.ringBufferLoopRange = data.main.ringBufferLoopRange;
        main.cullingMode = data.main.cullingMode;
        var emission = ps.emission;
        emission.enabled = data.emission.enabled;
        emission.rateOverTime = data.emission.rateOverTime;
        emission.rateOverTimeMultiplier = data.emission.rateOverTimeMultiplier;
        emission.rateOverDistance = data.emission.rateOverDistance;
        emission.rateOverDistanceMultiplier = data.emission.rateOverDistanceMultiplier;
        emission.burstCount = data.emission.burstCount;
        var shape = ps.shape;
        shape.enabled = data.shape.enabled;
        shape.shapeType = data.shape.shapeType;
        shape.randomDirectionAmount = data.shape.randomDirectionAmount;
        shape.sphericalDirectionAmount = data.shape.sphericalDirectionAmount;
        shape.randomPositionAmount = data.shape.randomPositionAmount;
        shape.alignToDirection = data.shape.alignToDirection;
        shape.radius = data.shape.radius;
        shape.radiusMode = data.shape.radiusMode;
        shape.radiusSpread = data.shape.radiusSpread;
        shape.radiusSpeed = data.shape.radiusSpeed;
        shape.radiusSpeedMultiplier = data.shape.radiusSpeedMultiplier;
        shape.radiusThickness = data.shape.radiusThickness;
        shape.angle = data.shape.angle;
        shape.length = data.shape.length;
        shape.boxThickness = data.shape.boxThickness;
        shape.meshShapeType = data.shape.meshShapeType;
        shape.mesh = data.shape.mesh;
        shape.meshRenderer = data.shape.meshRenderer;
        shape.skinnedMeshRenderer = data.shape.skinnedMeshRenderer;
        shape.sprite = data.shape.sprite;
        shape.spriteRenderer = data.shape.spriteRenderer;
        shape.useMeshMaterialIndex = data.shape.useMeshMaterialIndex;
        shape.meshMaterialIndex = data.shape.meshMaterialIndex;
        shape.useMeshColors = data.shape.useMeshColors;
        shape.normalOffset = data.shape.normalOffset;
        shape.meshSpawnMode = data.shape.meshSpawnMode;
        shape.meshSpawnSpread = data.shape.meshSpawnSpread;
        shape.meshSpawnSpeed = data.shape.meshSpawnSpeed;
        shape.meshSpawnSpeedMultiplier = data.shape.meshSpawnSpeedMultiplier;
        shape.arc = data.shape.arc;
        shape.arcMode = data.shape.arcMode;
        shape.arcSpread = data.shape.arcSpread;
        shape.arcSpeed = data.shape.arcSpeed;
        shape.arcSpeedMultiplier = data.shape.arcSpeedMultiplier;
        shape.donutRadius = data.shape.donutRadius;
        shape.position = data.shape.position;
        shape.rotation = data.shape.rotation;
        shape.scale = data.shape.scale;
        shape.texture = data.shape.texture;
        shape.textureClipChannel = data.shape.textureClipChannel;
        shape.textureClipThreshold = data.shape.textureClipThreshold;
        shape.textureColorAffectsParticles = data.shape.textureColorAffectsParticles;
        shape.textureAlphaAffectsParticles = data.shape.textureAlphaAffectsParticles;
        shape.textureBilinearFiltering = data.shape.textureBilinearFiltering;
        shape.textureUVChannel = data.shape.textureUVChannel;
        var velocityOverLifetime = ps.velocityOverLifetime;
        velocityOverLifetime.enabled = data.velocityOverLifetime.enabled;
        velocityOverLifetime.x = data.velocityOverLifetime.x;
        velocityOverLifetime.y = data.velocityOverLifetime.y;
        velocityOverLifetime.z = data.velocityOverLifetime.z;
        velocityOverLifetime.xMultiplier = data.velocityOverLifetime.xMultiplier;
        velocityOverLifetime.yMultiplier = data.velocityOverLifetime.yMultiplier;
        velocityOverLifetime.zMultiplier = data.velocityOverLifetime.zMultiplier;
        velocityOverLifetime.orbitalX = data.velocityOverLifetime.orbitalX;
        velocityOverLifetime.orbitalY = data.velocityOverLifetime.orbitalY;
        velocityOverLifetime.orbitalZ = data.velocityOverLifetime.orbitalZ;
        velocityOverLifetime.orbitalXMultiplier = data.velocityOverLifetime.orbitalXMultiplier;
        velocityOverLifetime.orbitalYMultiplier = data.velocityOverLifetime.orbitalYMultiplier;
        velocityOverLifetime.orbitalZMultiplier = data.velocityOverLifetime.orbitalZMultiplier;
        velocityOverLifetime.orbitalOffsetX = data.velocityOverLifetime.orbitalOffsetX;
        velocityOverLifetime.orbitalOffsetY = data.velocityOverLifetime.orbitalOffsetY;
        velocityOverLifetime.orbitalOffsetZ = data.velocityOverLifetime.orbitalOffsetZ;
        velocityOverLifetime.orbitalOffsetXMultiplier = data.velocityOverLifetime.orbitalOffsetXMultiplier;
        velocityOverLifetime.orbitalOffsetYMultiplier = data.velocityOverLifetime.orbitalOffsetYMultiplier;
        velocityOverLifetime.orbitalOffsetZMultiplier = data.velocityOverLifetime.orbitalOffsetZMultiplier;
        velocityOverLifetime.radial = data.velocityOverLifetime.radial;
        velocityOverLifetime.radialMultiplier = data.velocityOverLifetime.radialMultiplier;
        velocityOverLifetime.speedModifier = data.velocityOverLifetime.speedModifier;
        velocityOverLifetime.speedModifierMultiplier = data.velocityOverLifetime.speedModifierMultiplier;
        velocityOverLifetime.space = data.velocityOverLifetime.space;
        var limitVelocityOverLifetime = ps.limitVelocityOverLifetime;
        limitVelocityOverLifetime.enabled = data.limitVelocityOverLifetime.enabled;
        limitVelocityOverLifetime.limitX = data.limitVelocityOverLifetime.limitX;
        limitVelocityOverLifetime.limitXMultiplier = data.limitVelocityOverLifetime.limitXMultiplier;
        limitVelocityOverLifetime.limitY = data.limitVelocityOverLifetime.limitY;
        limitVelocityOverLifetime.limitYMultiplier = data.limitVelocityOverLifetime.limitYMultiplier;
        limitVelocityOverLifetime.limitZ = data.limitVelocityOverLifetime.limitZ;
        limitVelocityOverLifetime.limitZMultiplier = data.limitVelocityOverLifetime.limitZMultiplier;
        limitVelocityOverLifetime.limit = data.limitVelocityOverLifetime.limit;
        limitVelocityOverLifetime.limitMultiplier = data.limitVelocityOverLifetime.limitMultiplier;
        limitVelocityOverLifetime.dampen = data.limitVelocityOverLifetime.dampen;
        limitVelocityOverLifetime.separateAxes = data.limitVelocityOverLifetime.separateAxes;
        limitVelocityOverLifetime.space = data.limitVelocityOverLifetime.space;
        limitVelocityOverLifetime.drag = data.limitVelocityOverLifetime.drag;
        limitVelocityOverLifetime.dragMultiplier = data.limitVelocityOverLifetime.dragMultiplier;
        limitVelocityOverLifetime.multiplyDragByParticleSize =
            data.limitVelocityOverLifetime.multiplyDragByParticleSize;
        limitVelocityOverLifetime.multiplyDragByParticleVelocity =
            data.limitVelocityOverLifetime.multiplyDragByParticleVelocity;
        var inheritVelocity = ps.inheritVelocity;
        inheritVelocity.enabled = data.inheritVelocity.enabled;
        inheritVelocity.mode = data.inheritVelocity.mode;
        inheritVelocity.curve = data.inheritVelocity.curve;
        inheritVelocity.curveMultiplier = data.inheritVelocity.curveMultiplier;
        var lifetimeByEmitterSpeed = ps.lifetimeByEmitterSpeed;
        lifetimeByEmitterSpeed.enabled = data.lifetimeByEmitterSpeed.enabled;
        lifetimeByEmitterSpeed.curve = data.lifetimeByEmitterSpeed.curve;
        lifetimeByEmitterSpeed.curveMultiplier = data.lifetimeByEmitterSpeed.curveMultiplier;
        lifetimeByEmitterSpeed.range = data.lifetimeByEmitterSpeed.range;
        var forceOverLifetime = ps.forceOverLifetime;
        forceOverLifetime.enabled = data.forceOverLifetime.enabled;
        forceOverLifetime.x = data.forceOverLifetime.x;
        forceOverLifetime.y = data.forceOverLifetime.y;
        forceOverLifetime.z = data.forceOverLifetime.z;
        forceOverLifetime.xMultiplier = data.forceOverLifetime.xMultiplier;
        forceOverLifetime.yMultiplier = data.forceOverLifetime.yMultiplier;
        forceOverLifetime.zMultiplier = data.forceOverLifetime.zMultiplier;
        forceOverLifetime.space = data.forceOverLifetime.space;
        forceOverLifetime.randomized = data.forceOverLifetime.randomized;
        var colorOverLifetime = ps.colorOverLifetime;
        colorOverLifetime.enabled = data.colorOverLifetime.enabled;
        colorOverLifetime.color = data.colorOverLifetime.color;
        var colorBySpeed = ps.colorBySpeed;
        colorBySpeed.enabled = data.colorBySpeed.enabled;
        colorBySpeed.color = data.colorBySpeed.color;
        colorBySpeed.range = data.colorBySpeed.range;
        var sizeOverLifetime = ps.sizeOverLifetime;
        sizeOverLifetime.enabled = data.sizeOverLifetime.enabled;
        sizeOverLifetime.size = data.sizeOverLifetime.size;
        sizeOverLifetime.sizeMultiplier = data.sizeOverLifetime.sizeMultiplier;
        sizeOverLifetime.x = data.sizeOverLifetime.x;
        sizeOverLifetime.xMultiplier = data.sizeOverLifetime.xMultiplier;
        sizeOverLifetime.y = data.sizeOverLifetime.y;
        sizeOverLifetime.yMultiplier = data.sizeOverLifetime.yMultiplier;
        sizeOverLifetime.z = data.sizeOverLifetime.z;
        sizeOverLifetime.zMultiplier = data.sizeOverLifetime.zMultiplier;
        sizeOverLifetime.separateAxes = data.sizeOverLifetime.separateAxes;
        var sizeBySpeed = ps.sizeBySpeed;
        sizeBySpeed.enabled = data.sizeBySpeed.enabled;
        sizeBySpeed.size = data.sizeBySpeed.size;
        sizeBySpeed.sizeMultiplier = data.sizeBySpeed.sizeMultiplier;
        sizeBySpeed.x = data.sizeBySpeed.x;
        sizeBySpeed.xMultiplier = data.sizeBySpeed.xMultiplier;
        sizeBySpeed.y = data.sizeBySpeed.y;
        sizeBySpeed.yMultiplier = data.sizeBySpeed.yMultiplier;
        sizeBySpeed.z = data.sizeBySpeed.z;
        sizeBySpeed.zMultiplier = data.sizeBySpeed.zMultiplier;
        sizeBySpeed.separateAxes = data.sizeBySpeed.separateAxes;
        sizeBySpeed.range = data.sizeBySpeed.range;
        var rotationOverLifetime = ps.rotationOverLifetime;
        rotationOverLifetime.enabled = data.rotationOverLifetime.enabled;
        rotationOverLifetime.x = data.rotationOverLifetime.x;
        rotationOverLifetime.xMultiplier = data.rotationOverLifetime.xMultiplier;
        rotationOverLifetime.y = data.rotationOverLifetime.y;
        rotationOverLifetime.yMultiplier = data.rotationOverLifetime.yMultiplier;
        rotationOverLifetime.z = data.rotationOverLifetime.z;
        rotationOverLifetime.zMultiplier = data.rotationOverLifetime.zMultiplier;
        rotationOverLifetime.separateAxes = data.rotationOverLifetime.separateAxes;
        var rotationBySpeed = ps.rotationBySpeed;
        rotationBySpeed.enabled = data.rotationBySpeed.enabled;
        rotationBySpeed.x = data.rotationBySpeed.x;
        rotationBySpeed.xMultiplier = data.rotationBySpeed.xMultiplier;
        rotationBySpeed.y = data.rotationBySpeed.y;
        rotationBySpeed.yMultiplier = data.rotationBySpeed.yMultiplier;
        rotationBySpeed.z = data.rotationBySpeed.z;
        rotationBySpeed.zMultiplier = data.rotationBySpeed.zMultiplier;
        rotationBySpeed.separateAxes = data.rotationBySpeed.separateAxes;
        rotationBySpeed.range = data.rotationBySpeed.range;
        var externalForces = ps.externalForces;
        externalForces.enabled = data.externalForces.enabled;
        externalForces.multiplier = data.externalForces.multiplier;
        externalForces.multiplierCurve = data.externalForces.multiplierCurve;
        externalForces.influenceFilter = data.externalForces.influenceFilter;
        externalForces.influenceMask = data.externalForces.influenceMask;
        var noise = ps.noise;
        noise.enabled = data.noise.enabled;
        noise.separateAxes = data.noise.separateAxes;
        noise.strength = data.noise.strength;
        noise.strengthMultiplier = data.noise.strengthMultiplier;
        noise.strengthX = data.noise.strengthX;
        noise.strengthXMultiplier = data.noise.strengthXMultiplier;
        noise.strengthY = data.noise.strengthY;
        noise.strengthYMultiplier = data.noise.strengthYMultiplier;
        noise.strengthZ = data.noise.strengthZ;
        noise.strengthZMultiplier = data.noise.strengthZMultiplier;
        noise.frequency = data.noise.frequency;
        noise.damping = data.noise.damping;
        noise.octaveCount = data.noise.octaveCount;
        noise.octaveMultiplier = data.noise.octaveMultiplier;
        noise.octaveScale = data.noise.octaveScale;
        noise.quality = data.noise.quality;
        noise.scrollSpeed = data.noise.scrollSpeed;
        noise.scrollSpeedMultiplier = data.noise.scrollSpeedMultiplier;
        noise.remapEnabled = data.noise.remapEnabled;
        noise.remap = data.noise.remap;
        noise.remapMultiplier = data.noise.remapMultiplier;
        noise.remapX = data.noise.remapX;
        noise.remapXMultiplier = data.noise.remapXMultiplier;
        noise.remapY = data.noise.remapY;
        noise.remapYMultiplier = data.noise.remapYMultiplier;
        noise.remapZ = data.noise.remapZ;
        noise.remapZMultiplier = data.noise.remapZMultiplier;
        noise.positionAmount = data.noise.positionAmount;
        noise.rotationAmount = data.noise.rotationAmount;
        noise.sizeAmount = data.noise.sizeAmount;
        var collision = ps.collision;
        collision.enabled = data.collision.enabled;
        collision.type = data.collision.type;
        collision.mode = data.collision.mode;
        collision.dampen = data.collision.dampen;
        collision.dampenMultiplier = data.collision.dampenMultiplier;
        collision.bounce = data.collision.bounce;
        collision.bounceMultiplier = data.collision.bounceMultiplier;
        collision.lifetimeLoss = data.collision.lifetimeLoss;
        collision.lifetimeLossMultiplier = data.collision.lifetimeLossMultiplier;
        collision.minKillSpeed = data.collision.minKillSpeed;
        collision.maxKillSpeed = data.collision.maxKillSpeed;
        collision.collidesWith = data.collision.collidesWith;
        collision.enableDynamicColliders = data.collision.enableDynamicColliders;
        collision.maxCollisionShapes = data.collision.maxCollisionShapes;
        collision.quality = data.collision.quality;
        collision.voxelSize = data.collision.voxelSize;
        collision.radiusScale = data.collision.radiusScale;
        collision.sendCollisionMessages = data.collision.sendCollisionMessages;
        collision.colliderForce = data.collision.colliderForce;
        collision.multiplyColliderForceByCollisionAngle = data.collision.multiplyColliderForceByCollisionAngle;
        collision.multiplyColliderForceByParticleSpeed = data.collision.multiplyColliderForceByParticleSpeed;
        collision.multiplyColliderForceByParticleSize = data.collision.multiplyColliderForceByParticleSize;
        var trigger = ps.trigger;
        trigger.enabled = data.trigger.enabled;
        trigger.inside = data.trigger.inside;
        trigger.outside = data.trigger.outside;
        trigger.enter = data.trigger.enter;
        trigger.exit = data.trigger.exit;
        trigger.colliderQueryMode = data.trigger.colliderQueryMode;
        trigger.radiusScale = data.trigger.radiusScale;
        var subEmitters = ps.subEmitters;
        subEmitters.enabled = data.subEmitters.enabled;
        var textureSheetAnimation = ps.textureSheetAnimation;
        textureSheetAnimation.enabled = data.textureSheetAnimation.enabled;
        textureSheetAnimation.mode = data.textureSheetAnimation.mode;
        textureSheetAnimation.timeMode = data.textureSheetAnimation.timeMode;
        textureSheetAnimation.fps = data.textureSheetAnimation.fps;
        textureSheetAnimation.numTilesX = data.textureSheetAnimation.numTilesX;
        textureSheetAnimation.numTilesY = data.textureSheetAnimation.numTilesY;
        textureSheetAnimation.animation = data.textureSheetAnimation.animation;
        textureSheetAnimation.rowMode = data.textureSheetAnimation.rowMode;
        textureSheetAnimation.frameOverTime = data.textureSheetAnimation.frameOverTime;
        textureSheetAnimation.frameOverTimeMultiplier = data.textureSheetAnimation.frameOverTimeMultiplier;
        textureSheetAnimation.startFrame = data.textureSheetAnimation.startFrame;
        textureSheetAnimation.startFrameMultiplier = data.textureSheetAnimation.startFrameMultiplier;
        textureSheetAnimation.cycleCount = data.textureSheetAnimation.cycleCount;
        textureSheetAnimation.rowIndex = data.textureSheetAnimation.rowIndex;
        textureSheetAnimation.uvChannelMask = data.textureSheetAnimation.uvChannelMask;
        textureSheetAnimation.speedRange = data.textureSheetAnimation.speedRange;
        var lights = ps.lights;
        lights.enabled = data.lights.enabled;
        lights.ratio = data.lights.ratio;
        lights.useRandomDistribution = data.lights.useRandomDistribution;
        lights.light = data.lights.light;
        lights.useParticleColor = data.lights.useParticleColor;
        lights.sizeAffectsRange = data.lights.sizeAffectsRange;
        lights.alphaAffectsIntensity = data.lights.alphaAffectsIntensity;
        lights.range = data.lights.range;
        lights.rangeMultiplier = data.lights.rangeMultiplier;
        lights.intensity = data.lights.intensity;
        lights.intensityMultiplier = data.lights.intensityMultiplier;
        lights.maxLights = data.lights.maxLights;
        var trails = ps.trails;
        trails.enabled = data.trails.enabled;
        trails.mode = data.trails.mode;
        trails.ratio = data.trails.ratio;
        trails.lifetime = data.trails.lifetime;
        trails.lifetimeMultiplier = data.trails.lifetimeMultiplier;
        trails.minVertexDistance = data.trails.minVertexDistance;
        trails.textureMode = data.trails.textureMode;
        trails.worldSpace = data.trails.worldSpace;
        trails.dieWithParticles = data.trails.dieWithParticles;
        trails.sizeAffectsWidth = data.trails.sizeAffectsWidth;
        trails.sizeAffectsLifetime = data.trails.sizeAffectsLifetime;
        trails.inheritParticleColor = data.trails.inheritParticleColor;
        trails.colorOverLifetime = data.trails.colorOverLifetime;
        trails.widthOverTrail = data.trails.widthOverTrail;
        trails.widthOverTrailMultiplier = data.trails.widthOverTrailMultiplier;
        trails.colorOverTrail = data.trails.colorOverTrail;
        trails.generateLightingData = data.trails.generateLightingData;
        trails.ribbonCount = data.trails.ribbonCount;
        trails.shadowBias = data.trails.shadowBias;
        trails.splitSubEmitterRibbons = data.trails.splitSubEmitterRibbons;
        trails.attachRibbonsToTransform = data.trails.attachRibbonsToTransform;
        var customData = ps.customData;
        customData.enabled = data.customData.enabled;
        ps.tag = data.tag;
        ps.name = data.name;
        ps.hideFlags = data.hideFlags;
    }
    #endregion

    private void OnEnable()
    {
        // 跳过第一次
        // if (!string.IsNullOrEmpty(data.name))
        // {
            // 这里是直接获取component，可以改造成从对象池中获取
            if (!TryGetComponent<ParticleSystem>(out var ps))
            {
                ps = gameObject.AddComponent<ParticleSystem>();
            }

            ps.Stop(false, ParticleSystemStopBehavior.StopEmittingAndClear);
            ApplyParticleSystemData(ps);
            ps.Play();
        // }
    }
    
    private void OnDisable()
    {
        if (TryGetComponent<ParticleSystem>(out var ps))
        {
            RecordParticleSystemData(ps);
            // 这里是直接销毁 ps，可以改造成放回对象池
            Destroy(ps);
        }
    }
}
